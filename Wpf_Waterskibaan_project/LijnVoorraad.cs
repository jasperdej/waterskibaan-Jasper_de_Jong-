using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    public class LijnVoorraad
    {
        public Queue<Lijn> _lijnen;

        public LijnVoorraad()
        {
            _lijnen = new Queue<Lijn>();
        }

        public void LijnToevoegenAanRij(Lijn lijn)
        {
            _lijnen.Enqueue(lijn);
        }

        public Lijn VerwijderEersteLijn()
        {
            Lijn lijn;
            try
            {
                lijn = _lijnen.Dequeue();
                return lijn;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public int GetAantalLijnen()
        {
            return _lijnen.Count();
        }

        public override string ToString()
        {
            return $"{_lijnen.Count()} lijnen op voorraad";
        }
    }
}
