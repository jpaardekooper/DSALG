using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dentist
{
    class PickerFaster : Picker
    {
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
            return room.OrderBy(x => x.Duration).ThenByDescending(x => x.Number).First();
        }
    }
}
