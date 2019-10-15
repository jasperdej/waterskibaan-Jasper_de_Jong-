using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    public class EenBeen : IMoves
    {
        public EenBeen()
        {

        }
        public int Move()
        {
            Random rnd = new Random();
            int result = rnd.Next(0, 2);
            if (result == 1)
            {
                return 70;
            }
            else
            {
                return 0;
            }
        }
    }
}
