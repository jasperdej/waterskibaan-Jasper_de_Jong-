using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Wpf_Waterskibaan_project
{

    class Game
    {
        public Waterskibaan wsb;

        public void Initialise()
        {
            wsb = new Waterskibaan();
            while (true)
            {
                loop();
            }
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
        }
    }
}
