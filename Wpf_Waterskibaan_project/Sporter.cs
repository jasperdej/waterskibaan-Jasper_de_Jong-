using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    class Sporter : IMoves 
    {
        public int AantalRondenNogTeGaan { get; set; } = 0;
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        //public Color KledingKleur { get; set; }

        public List<IMoves> Moves;

        public Sporter(List<IMoves> moves)
        {
            Moves = moves;
        }

        public int Move()
        {
            throw new NotImplementedException();
        }
    }
}
