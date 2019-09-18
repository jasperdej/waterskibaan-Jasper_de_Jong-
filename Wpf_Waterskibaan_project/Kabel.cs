using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    class Kabel
    {

        private LinkedList<Lijn> _lijnen;

        public Boolean IsStartPositieLeeg()
        {
            if(_lijnen[0] == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void NeemLijnInGebruik(Lijn lijn)
        {

        }

        public void VerschuifLijnen()
        {

        }

        public Lijn VerwijderLijnVanKabel()
        {

        }

        public string ToString()
        {

        }
    }
}
