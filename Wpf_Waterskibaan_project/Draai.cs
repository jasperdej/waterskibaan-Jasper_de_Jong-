using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    public class Draai : IMoves
    {
        public Draai()
        {

        }
        public int Move()
        {
            Random rnd = new Random();
            int result = rnd.Next(0, 4);
            if (result == 1)
            {
                return 20;
            }
            else
            {
                return 0;
            }
        }
    }
}
