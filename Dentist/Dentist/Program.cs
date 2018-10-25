using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dentist
{
    class Program
    {    

        static void Main(string[] args)
        {
            double score1, score2, score3, score4, score5, score6;
            double gemiddeld;
            double gemiddeld2;
            Scheduler wachtrij = new Scheduler();
            Picker picker = new PickerTim();   
            Picker picker2 = new PickerFaster();

            Console.WriteLine("Elke ronde wachten kost " + Scheduler.WAIT_TIME +" punten");
            Console.WriteLine("Meer dan 10 ronden wachten kost " + Scheduler.STARVATION_10 + " punten extra");
            Console.WriteLine("Meer dan 20 ronden wachten kost " + Scheduler.STARVATION_20 + " punten extra");
            Console.WriteLine("\n");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here 

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
            score5 = wachtrij.doline("../../../langmakkelijk.txt", picker);
            Console.WriteLine("De langmakkelijk wachtrij scoorde {0:N2}", score5);
            score6 = wachtrij.doline("../../../langmoeilijk.txt", picker);
            Console.WriteLine("De langmoeilijke wachtrij scoorde {0:N2}", score6);
            gemiddeld = (score1 + score2 + score3 + score4 + score5 + score6) / 6.0;
            Console.WriteLine("Gemiddelde score: {0:N2}", gemiddeld);
            Console.WriteLine("*****\n");

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("het duurde in totaal:" + elapsedMs + "ms");

            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here 
            Console.WriteLine("\n*****");
            Console.WriteLine(picker2.GeefNamen());
            score1 = wachtrij.doline("../../../kort.txt", picker2);
            Console.WriteLine("De korte wachtrij scoorde {0:N2}", score1);
            score2 = wachtrij.doline("../../../lang.txt", picker2);
            Console.WriteLine("De lange wachtrij scoorde {0:N2}", score2);
            score3 = wachtrij.doline("../../../omgekeerd.txt", picker2);
            Console.WriteLine("De omgekeerde wachtrij scoorde {0:N2}", score3);
            score4 = wachtrij.doline("../../../eigentest.txt", picker2);
            Console.WriteLine("De zelfgemaakte wachtrij scoorde {0:N2}", score4);
            score5 = wachtrij.doline("../../../langmakkelijk.txt", picker2);
            Console.WriteLine("De langmakkelijk wachtrij scoorde {0:N2}", score5);
            score6 = wachtrij.doline("../../../langmoeilijk.txt", picker2);
            Console.WriteLine("De langmoeilijke wachtrij scoorde {0:N2}", score6);
            gemiddeld2 = (score1 + score2 + score3 + score4 + score5 + score6) / 6.0;
            Console.WriteLine("Gemiddelde score: {0:N2}", gemiddeld2);
            Console.WriteLine("*****\n");

            watch2.Stop();
            var elapsedMs2 = watch2.ElapsedMilliseconds;
            Console.WriteLine("het duurde in totaal:" + elapsedMs2 + "ms");
         
            Console.ReadKey();
        }
    }
}
