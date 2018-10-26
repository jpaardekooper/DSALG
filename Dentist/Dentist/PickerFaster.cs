using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dentist
{
  
    class PickerFaster : Picker
    {
        Dictionary<Patient, int> f = new Dictionary<Patient, int>();

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
                if (!f.ContainsKey(item))
                {
                    f.Add(item, 0);
                }
                else
                {
                    f[item]++;
                }
            }

            int ShortestDuration = room.OrderBy(x => x.Duration).ThenBy(x => x.Arrival).First().Duration;

            List<Patient> InDangerOfPenalty = f.Where(x => x.Value + ShortestDuration > 10).Select(x => x.Key).ToList();

            if (InDangerOfPenalty.Any())
            {
                f.Remove(InDangerOfPenalty.OrderBy(x => x.Duration).ThenBy(x => x.Arrival).First());
                return InDangerOfPenalty.OrderBy(x => x.Duration).ThenBy(x => x.Arrival).First();
            }
            else
            {
                f.Remove(room.OrderBy(x => x.Duration).ThenBy(x => x.Arrival).First());
                return room.OrderBy(x => x.Duration).ThenBy(x => x.Arrival).First();
            }           
        }
    }
}
