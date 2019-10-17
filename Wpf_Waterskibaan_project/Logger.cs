using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
            alleBezoekers.Add(sp);
        }
        private bool ColorsClose(Color original, Color goal, int threshold = 50)
        {
            int r = (int)original.R - goal.R;
            int g = (int)original.G - goal.G;
            int b = (int)original.B - goal.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        public string GetResultaten()
        {
            //1 Gooi int in string
            int aantalBezoekers = (from x in alleBezoekers select x).Count();
            //2 neem Tostring van sporter ofzo met punten, later nog ervoor zorgen dat af en toe behaaldepunten in de lijst wordt geupdate
            var meestePunten = alleBezoekers.OrderBy(i => i.behaaldePunten).Take(1);
            Sporter besteSporter = (Sporter)meestePunten;
            //3 Een foreach gebruiken om een lijst op te stellen
            var aantalRood = alleBezoekers.Where(i => ColorsClose(i.KledingKleur, Color.FromRgb(255, 0, 0)));
            List<Sporter> aantalRodeSporters = new List<Sporter>();
            foreach (Sporter sp in aantalRood)
            {
                aantalRodeSporters.Add(sp);
            }
            //4 Zelfde als bij 3
            var lichtsteKleuren = alleBezoekers.OrderBy(i => ((i.KledingKleur.R * i.KledingKleur.R) + (i.KledingKleur.G * i.KledingKleur.G) + (i.KledingKleur.B * i.KledingKleur.B))).Take(10);
            List<Sporter> sportersLichtsteKleuren = new List<Sporter>();
            foreach (Sporter sp in lichtsteKleuren)
            {
                sportersLichtsteKleuren.Add(sp);
            }
            //5 Hier juist niet de lijst updaten
            var aantalRondes = alleBezoekers.Select(i => i.AantalRondenNogTeGaan);
            int resultaat = 0;
            foreach (int i in aantalRondes)
            {
                resultaat += i;
            }
            //6 Gooi hier ook een tostringetje in ofzo
            var alleMoves = alleBezoekers.Select(i => i.Moves);
            List<IMoves> uniekeMoves = new List<IMoves>();
            foreach (IMoves im in alleMoves)
            {
                uniekeMoves.Add(im);
            }

            string output = "";
            return output;
        }
    }
}
