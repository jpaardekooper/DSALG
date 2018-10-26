using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist
{
    class PickerTim : Picker
    {
        public string GeefNamen()
        {
            return "Tim Cocx";
        }

        public Patient selectPatient(List<Patient> room, int clock)
        {
           return room.First();   
          
        }
    }
}
