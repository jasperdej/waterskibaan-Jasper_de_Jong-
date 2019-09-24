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
            if(_lijnen.ElementAt(0) == null)
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
            if (_lijnen.ElementAt(0) == null)
            {
                _lijnen.First.Value = lijn;
            }
            else
            {
                Console.WriteLine("Lijn niet toegevoegd, positie is al vol");
            }

        }

        public void VerschuifLijnen()
        {
            for(int i = 0; i < 9; i++)
            {

            }
        }

        public Lijn VerwijderLijnVanKabel()
        {

        }

        public string ToString()
        {

        }
    }
}
