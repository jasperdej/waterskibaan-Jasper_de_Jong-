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
        public int rondes;
        Waterskibaan wsb;
        public Logger(Game game, Waterskibaan waterskibaan)
        {
            alleBezoekers = new List<Sporter>();
            wsb = waterskibaan;
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

        public void RefreshPunten()
        {
            foreach(Sporter sp in alleBezoekers)
            {
            }
        }

        public string GetResultaten()
        {
            string output = "";
            if (alleBezoekers != null)
            {
                //1
                int aantalBezoekers = (from x in alleBezoekers select x).Count();
                output += $"Bezoekers: {aantalBezoekers} \n";
                //2
                var meestePunten = alleBezoekers.OrderBy(i => i.behaaldePunten).Take(1).ToList();
                Sporter besteSporter = null;
                foreach(Sporter sp in meestePunten)
                {
                    besteSporter = sp;
                }
                output += $"Highscore: {besteSporter.behaaldePunten} \n";
                //3
                var aantalRood = alleBezoekers.Where(i => ColorsClose(i.KledingKleur, Color.FromRgb(255, 0, 0)));
                List<Sporter> aantalRodeSporters = new List<Sporter>();
                foreach (Sporter sp in aantalRood)
                {
                    aantalRodeSporters.Add(sp);
                }
                output += $"Rood: \n";
                foreach (Sporter sp in aantalRodeSporters)
                {
                    output += $"{sp.ToString()},";
                }
                output += "\n";
                //4
                var lichtsteKleuren = alleBezoekers.OrderBy(i => ((i.KledingKleur.R * i.KledingKleur.R) + (i.KledingKleur.G * i.KledingKleur.G) + (i.KledingKleur.B * i.KledingKleur.B))).Take(10);
                List<Sporter> sportersLichtsteKleuren = new List<Sporter>();
                output += $"Licht: \n";
                foreach (Sporter sp in lichtsteKleuren)
                {
                    sportersLichtsteKleuren.Add(sp);
                }
                foreach (Sporter sp in sportersLichtsteKleuren)
                {
                    output += $"{sp.ToString()},";
                    output += "\n";
                }
                //5
                var aantalRondes = alleBezoekers.Select(i => i.AantalRondenNogTeGaan);
                int resultaat = 0;
                foreach (int i in aantalRondes)
                {
                    resultaat += i;
                }
                output += $"Rondes: {resultaat} \n";
                //6
                Queue<Lijn> lijnen = new Queue<Lijn>(wsb.lijnVoorraad._lijnen);
                if (lijnen.Count > 0 && lijnen.Peek().SporterAanLijn != null)
                {
                    var alleMoves = from item in alleBezoekers where lijnen.Dequeue().SporterAanLijn != null select item.Moves;
                    List<IMoves> uniekeMoves = new List<IMoves>();
                    foreach (IMoves im in alleMoves)
                    {
                        uniekeMoves.Add(im);
                    }
                    foreach (IMoves moves in uniekeMoves)
                    {
                        output += $"{moves}, \n";
                    }
                }
                    return output;
            }
            else
            {
                return "";
            }
        }
    }
}
