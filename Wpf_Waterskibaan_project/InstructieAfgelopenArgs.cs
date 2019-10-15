using System;
using System.Collections.Generic;

namespace Wpf_Waterskibaan_project
{
    public class InstructieAfgelopenArgs
    {
        public int AantalSporters { get; set; }
        Random rnd = new Random();

        public InstructieAfgelopenArgs(int aantal) {
            AantalSporters = aantal;
        }
    }
}