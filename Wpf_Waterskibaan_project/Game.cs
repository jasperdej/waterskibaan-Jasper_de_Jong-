using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Wpf_Waterskibaan_project
{

    public class Game
    {
        public Waterskibaan wsb;
        Random rnd = new Random();
        int counter = 0;

        public void Initialise()
        {
            wsb = new Waterskibaan();
            
            while (true)
            {
                loop();
            }
        }
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);

        public event NieuweBezoekerHandler NieuweBezoeker;
        public event InstructieAfgelopenHandler instructieAfgelopen;

        public void RaiseNieuweBezoeker(Sporter sp)
        {
            NieuweBezoeker(new NieuweBezoekerArgs(sp));
        }
        public void RaiseInstructieAfgelopen()
        {
            instructieAfgelopen(new InstructieAfgelopenArgs(rnd.Next(1,6)));
        }

    public void loop()
        {
            Zwemvest zw = new Zwemvest();
            Skies s = new Skies();
            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves(), zw, s);
            wsb.SporterStart(sporter);
            wsb.VerplaatsKabel();
            wsb.ToString();
            Thread.Sleep(1000);
            if (counter == 3)
            {
                RaiseNieuweBezoeker(sporter);
            }
            else if (counter == 20)
            {
                RaiseInstructieAfgelopen();
            }

            if(counter < 20)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
        }
    }
}
