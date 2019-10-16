using System;
using System.Collections.Generic;

namespace Wpf_Waterskibaan_project
{
    public class InstructieAfgelopenArgs
    {
        public int AantalSporters { get; set; }

        public InstructieAfgelopenArgs(int aantal) {
            AantalSporters = aantal;
        }
    }
}