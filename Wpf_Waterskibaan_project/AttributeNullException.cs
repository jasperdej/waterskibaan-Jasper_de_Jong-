using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    public class AttributeNullException : Exception
    {
        public AttributeNullException() :
       base("Geen skies en/of zwemvest bij deze sporter")
        {
        }

        public AttributeNullException(string msg) : base(msg)
        {
        }

    }
}
