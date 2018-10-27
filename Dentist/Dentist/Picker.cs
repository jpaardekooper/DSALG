using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist
{
    public interface Picker
    {
        string GeefNamen();
        Patient selectPatient(List<Patient> room, int clock);
    }
}
