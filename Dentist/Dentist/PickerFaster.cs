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
                }
                else
                {
                    GlorifiedWaitList[item] += clock - lastClock;
                }
            }

            lastClock = clock;

            int ShortestDuration = GlorifiedWaitList.OrderBy(x => x.Key.Duration).Select(x => x.Key).First().Duration;

            Dictionary<Patient, int> InDangerOfPenalty = GlorifiedWaitList.Where(x => x.Value + ShortestDuration >= 10) as Dictionary<Patient, int>;
            
            if (InDangerOfPenalty != null && InDangerOfPenalty.Any())
            {
                Patient temp = InDangerOfPenalty.OrderBy(x => x.Value).ThenBy(x => x.Key.Arrival).First().Key;
                GlorifiedWaitList.Remove(temp);
                return temp;
            }
            else
            {
                Patient temp = room.OrderBy(x => x.Duration).ThenBy(x => x.Arrival).First();
                GlorifiedWaitList.Remove(temp);
                return temp;
            }           
        }
    }
}
