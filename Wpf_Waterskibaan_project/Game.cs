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

        public void Initialise()
        {
            wsb = new Waterskibaan();
            
            while (true)
            {
                loop();
            }
        }
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);

        public event NieuweBezoekerHandler NieuweBezoeker;
        

    public void loop()
        {
            Zwemvest zw = new Zwemvest();
            Skies s = new Skies();
            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves(), zw, s);
            wsb.SporterStart(sporter);
            wsb.VerplaatsKabel();
            wsb.ToString();
            Thread.Sleep(1000);
            if(rnd.Next(0,2) == 1)
            {
                NieuweBezoeker(new NieuweBezoekerArgs(sporter));
            }
        }
    }
}
