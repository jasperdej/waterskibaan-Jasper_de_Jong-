using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Wpf_Waterskibaan_project
{

    class Game
    {
        public Waterskibaan wsb;
        public static void Main()
        {
            wsb = new Waterskibaan();
            void loop()
            {
                Zwemvest zw = new Zwemvest();
                Skies s = new Skies();
                Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves(), zw, s);
                wsb.SporterStart(sporter);
            }
        }
    } }
