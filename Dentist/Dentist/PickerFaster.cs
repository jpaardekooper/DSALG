using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dentist
{

    class PickerFaster : Picker
    {
        Dictionary<Patient, int> GlorifiedWaitList = new Dictionary<Patient, int>();

        public int lastClock;

        public int gem = 0;
        public int count = 0;


        public string GeefNamen()
        {
            return "Jasper en Marnix";
        }

        /// <summary>
        /// Offline scheduling
        /// </summary>
        /// <param name="room"></param>
        /// <param name="clock"></param>
        /// <returns></returns>
        public Patient selectPatient(List<Patient> room, int clock)
        {
            foreach (var item in room)
            {
                if (!GlorifiedWaitList.ContainsKey(item))
                {
                    GlorifiedWaitList.Add(item, 0);
                    gem += item.Duration;
                    count++;
                }
                else
                {
                    GlorifiedWaitList[item] += clock - lastClock;
                }
            }
            
            int ShortestDuration = GlorifiedWaitList.OrderBy(x => x.Key.Duration).Select(x => x.Key).First().Duration;

            Dictionary<Patient, int> InDangerOfPenalty = new Dictionary<Patient, int>();
            Dictionary<Patient, int> closeToDanger = new Dictionary<Patient, int>();

            if (ShortestDuration > 10)
            {
                InDangerOfPenalty = GlorifiedWaitList.Where(x => x.Value + ShortestDuration > 20).ToDictionary(x => x.Key, x => x.Value);
            }
            else
            {
                InDangerOfPenalty = GlorifiedWaitList.Where(x => x.Value + ShortestDuration > 10).ToDictionary(x => x.Key, x => x.Value);
            }

            if (gem / count > 10)
            {
                closeToDanger = GlorifiedWaitList.Where(x => x.Value + (gem / count * 3) > 20).ToDictionary(x => x.Key, x => x.Value);
            }
            else
            {
                closeToDanger = GlorifiedWaitList.Where(x => x.Value + (gem / count * 3) > 10).ToDictionary(x => x.Key, x => x.Value);
            }

            if (InDangerOfPenalty.Any())
            {
                if (InDangerOfPenalty.Count() > closeToDanger.Count())
                {
                    Patient temp = InDangerOfPenalty.OrderBy(x => x.Key.Duration).First().Key;
                    GlorifiedWaitList.Remove(temp);
                    return temp;
                }
                else
                {
                    Patient temp = closeToDanger.OrderBy(x => x.Key.Duration).First().Key;
                    GlorifiedWaitList.Remove(temp);
                    return temp;
                }
                
            }
            else
            {
                Patient temp = room.OrderBy(x => x.Duration).First();
                GlorifiedWaitList.Remove(temp);
                return temp;
            }
        }
    }
}
