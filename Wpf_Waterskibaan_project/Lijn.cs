﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    public class Lijn
    {
        public int PositieOpDeKabel { get; set; }

        public Sporter SporterAanLijn { get; set; }

        public Lijn(int positie, Sporter sporter)
        {
            PositieOpDeKabel = positie;
            SporterAanLijn = sporter;
        }

        public override string ToString()
        {
            return $"{PositieOpDeKabel}";
        }
    }
}
