using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist
{
    class Scheduler
    {

        public const int WAIT_TIME = 1;
        public const int STARVATION_10 = 10;
        public const int STARVATION_20 = 20;
        public const bool LOGDETAIL = true;
        public const bool LOGSYNOPS = true;

        private int[,] generateList(int num)
        {

            const int MAXDURATION = 8;
            const int PERCLONG = 25;
            const int PERCMEDIUM = 65;
            const int LIMMEDIUM = 4;
            const int LIMLONG = 7;

            int size, dur;
            int totdur = 0;
            Random rand = new Random();
            int[,] temp = new int[num, 2];

            for (int i = 0; i < num; i++)
            {
                size = rand.Next(1, 101);
                if (size < PERCLONG)
                {
                    dur = rand.Next(LIMLONG, MAXDURATION + 1);
                }
                else if (size < PERCMEDIUM)
                {
                    dur = rand.Next(LIMMEDIUM, LIMLONG);
                }
                else
                {
                    dur = rand.Next(1, LIMMEDIUM);
                }
                temp[i, 1] = dur;
                totdur += dur;
            }

            int clock = 1;
            for (int i = 0; i < num; i++)
            {
                temp[i, 0] = clock;
                clock += rand.Next(0, 10);
            }

            return temp;
        }
        public void generate(string filename)
        {
            int num = 10000;
            int[,] explist = generateList(num);
            using (StreamWriter sr = new StreamWriter(filename))
            {
                for (int i = 0; i < num; i++)
                {
                    sr.WriteLine(explist[i, 0]);
                    sr.WriteLine(explist[i, 1]);
                }
            }
        }

        private List<Patient> readin(string filename)
        {
            List<Patient> patientList = new List<Patient>();
            Patient temp;
            int number = 1;
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        temp = new Patient();
                        temp.Arrival = int.Parse(line);
                        temp.Duration = int.Parse(sr.ReadLine());
                        temp.Number = number;
                        patientList.Add(temp);
                        number++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return patientList;
        }

        private void enterRoom(List<Patient> all, List<Patient> room, int clock)
        {
            for (int i = 0; i < all.Count; i++)
            {
                Patient cur = all.ElementAt(i);
                if (cur.Arrival <= clock)
                {
                    room.Add(cur);
                    if (LOGDETAIL) Console.WriteLine("Op moment " + cur.Arrival + " komt patient " + cur.Number + " binnen voor een behandeling van " + cur.Duration + " cycles.");
                    all.RemoveAt(i);
                    i--;
                }
                else
                {
                    break;
                }
            }
        }

        public double doline(string filename, Picker picker)
        {
            int score = 0;
            int clock = 1;
            List<Patient> all = readin(filename);
            List<Patient> room = new List<Patient>();
            Patient cur;
            int wait;
            int sumDuration = 0;
            int pats = all.Count;
            int lastArrival = 0;

            if (LOGSYNOPS)
            {
                foreach (Patient cur2 in all)
                {
                    sumDuration += cur2.Duration;
                }
                lastArrival = all.Last().Arrival;
            }

            enterRoom(all, room, clock);
            while ((all.Count > 0 && clock <= all.Last().Arrival) || room.Count > 0)
            {
                if (room.Count > 0)
                {
                    cur = picker.selectPatient(room, clock);
                    wait = clock - cur.Arrival;
                    score += ((wait * WAIT_TIME) + (wait > 10 ? STARVATION_10 : 0) + (wait > 20 ? STARVATION_20 : 0));
                    if (LOGDETAIL) Console.WriteLine("Op moment " + clock + " wordt patient " + cur.Number + " geholpen. Dit duurt " + cur.Duration + " cycles. De patient heeft " + wait + " cycles gewacht. Score is nu: " + score);
                    clock += cur.Duration;
                    room.Remove(cur);
                }
                else
                {
                    clock = all.First().Arrival;
                }
                enterRoom(all, room, clock);
            }
            if (LOGSYNOPS)
            {
                Console.WriteLine("\nxxxxx");
                Console.WriteLine("Patienten: " + pats);
                Console.WriteLine("Behandeltijd: " + sumDuration);
                Console.WriteLine("Laatste binnenkomst: " + lastArrival);
                Console.WriteLine("Score: " + score);
                Console.WriteLine("Score per Patient: {0:N2}", ((double)score) / pats);
                Console.WriteLine("xxxxx\n");
            }
            return ((double)score) / pats;
        }
    }
}
