using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    public class NieuweBezoekerArgs
    {
        Sporter Sporter { get; set; }
        

        public NieuweBezoekerArgs(Sporter sp)
        {
            Sporter = sp;
        }
    }
}
