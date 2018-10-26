using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dentist
{
  
    class PickerFaster : Picker
    {


        private Dictionary<Patient, int> InTreatment { get; set; } = new Dictionary<Patient, int>();
        private Dictionary<Patient, int> InRoom { get; set; } = new Dictionary<Patient, int>();

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
            Patient toRoom = null;

            foreach (var Patiant in room)
            {
                if (!InRoom.ContainsKey(Patiant))
                {
                    InRoom.Add(Patiant, clock);
                }
                else
                {
                    InRoom[Patiant]++;
                }
            }



            InTreatment.Add(toRoom, clock);
            return toRoom;
        }
    }
}
