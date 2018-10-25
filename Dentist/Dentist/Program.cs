using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist
{
    class Program
    {
        static void Main(string[] args)
        {
            double score1, score2, score3, score4;
            double gemiddeld;
            Scheduler wachtrij = new Scheduler();
            Picker picker = new PickerTim();

            Console.WriteLine("Elke ronde wachten kost " + Scheduler.WAIT_TIME +" punten");
            Console.WriteLine("Meer dan 10 ronden wachten kost " + Scheduler.STARVATION_10 + " punten extra");
            Console.WriteLine("Meer dan 20 ronden wachten kost " + Scheduler.STARVATION_20 + " punten extra");
            Console.WriteLine("\n");

            Console.WriteLine("\n*****");
            Console.WriteLine(picker.GeefNamen()); 
            score1 = wachtrij.doline("../../../kort.txt", picker);
            Console.WriteLine("De korte wachtrij scoorde {0:N2}", score1);
            score2 = wachtrij.doline("../../../lang.txt", picker);
            Console.WriteLine("De lange wachtrij scoorde {0:N2}", score2);
            score3 = wachtrij.doline("../../../omgekeerd.txt", picker);
            Console.WriteLine("De omgekeerde wachtrij scoorde {0:N2}", score3);
            score4 = wachtrij.doline("../../../eigentest.txt", picker);
            Console.WriteLine("De zelfgemaakte wachtrij scoorde {0:N2}", score4);
            gemiddeld = (score1 + score2 + score3 + score4) / 4.0;
            Console.WriteLine("Gemiddelde score: {0:N2}", gemiddeld);
            Console.WriteLine("*****\n");
            Console.ReadKey();
        }
    }
}
