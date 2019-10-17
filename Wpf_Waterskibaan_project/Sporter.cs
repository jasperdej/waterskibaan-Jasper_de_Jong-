using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Wpf_Waterskibaan_project
{
    public class Sporter : IMoves
    {
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }

        public int behaaldePunten = 0;

        public List<IMoves> Moves { get; set; }
        public IMoves HuidigeMove { get; set; }
        public int count = 0;

        public Sporter(List<IMoves> moves, Zwemvest zwemvest, Skies skies)
        {
            Moves = moves;
            Zwemvest = zwemvest;
            Skies = skies;
            if (Moves.Count() != 0)
            {
                HuidigeMove = Moves.First();
            }
            else { HuidigeMove = null; }
        }

        public Sporter(List<IMoves> moves, Zwemvest zwemvest, Skies skies, Color kleur) : this(moves, zwemvest, skies)
        {
            KledingKleur = kleur;
        }

        public int Move()
        {
            int uitkomst;
            count++;
            if (count < Moves.Count)
            {
                uitkomst = HuidigeMove.Move();
                HuidigeMove = Moves[count];
            }
            else
            {
                uitkomst = 0;
            }
            HuidigeMove = Moves[count];
            return uitkomst;
        }

        public override string ToString()
        {
            return $"Kleur: {KledingKleur}";
        }
    }
}
