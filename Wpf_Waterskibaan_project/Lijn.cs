using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    class Lijn
    {
        public int PositieOpDeKabel { get; set; }

        public Lijn(int positie)
        {
            PositieOpDeKabel = positie;
        }
    }
}
