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
            // Checking and updating the waiting times
            // adding the new guests to the list
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

            // updating the time differance
            lastClock = clock;

            // Getting the shortest time for calculations
            int ShortestDuration = GlorifiedWaitList.OrderBy(x => x.Key.Duration).Select(x => x.Key).First().Duration;
            
            // Checkin if a patiant is in imidiate danger of getting a penalty
            // and adding him to a temprary collaction
            Dictionary<Patient, int> InDangerOfPenalty = GlorifiedWaitList.Where(x => x.Value + ShortestDuration > 10).ToDictionary(x => x.Key, x => x.Value);
            
            // Checkin if a patiant is in near future danger of getting a penalty
            // and adding him to a temprary collaction
            Dictionary<Patient, int>  closeToDanger = GlorifiedWaitList.Where(x => x.Value + (gem / count * 3) > 10).ToDictionary(x => x.Key, x => x.Value);

            // Checking if there are any guests in danger
            if (InDangerOfPenalty.Any())
            {
                // checking if there are more guests close to danger
                // it is better to get 1 penalty then 6 for example
                // so those should be handeld first
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
                // giving back the shortest guest
                Patient temp = room.OrderBy(x => x.Duration).First();
                GlorifiedWaitList.Remove(temp);
                return temp;
            }
        }
    }
}
