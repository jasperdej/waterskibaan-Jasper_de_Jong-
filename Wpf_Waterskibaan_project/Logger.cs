using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    public class Logger
    {
        public List<Sporter> alleBezoekers;
        public Logger(Game game)
        {
            alleBezoekers = new List<Sporter>();
            game.NieuweBezoeker += new Game.NieuweBezoekerHandler(LoggerHandleNieuweBezoeker);
        }
        public void LoggerHandleNieuweBezoeker(NieuweBezoekerArgs args)
        {
            Sporter sp = args.Sporter;
        }
    }
}
