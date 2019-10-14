using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    class Jump
    {
        public Jump()
        {

        }
        public int Move()
        {
            Random rnd = new Random();
            int result = rnd.Next(0, 2);
            if (result == 1)
            {
                return 40;
            }
            else
            {
                return 0;
            }
        }
    }
}
