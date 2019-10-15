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
        public int AantalRondenNogTeGaan { get; set; } = 0;
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }

        public int behaaldePunten = 0;

        public List<IMoves> Moves { get; set; }

        public Sporter(List<IMoves> moves, Zwemvest zwemvest, Skies skies)
        {
            Moves = moves;
            Zwemvest = zwemvest;
            Skies = skies;
        }

        public int Move()
        {
            throw new NotImplementedException();
        }
    }
}
