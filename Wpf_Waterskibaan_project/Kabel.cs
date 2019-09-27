using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    class Kabel
    {
        LinkedList<Lijn> _lijnen;

        public Kabel()
        {
            Lijn[] startLijnen = new Lijn[]{ null, null, null, null, null, null, null, null, null };
            _lijnen = new LinkedList<Lijn>(startLijnen);
        }
        public Boolean IsStartPositieLeeg()
        {
            try
            {
                if (_lijnen.ElementAt(0) == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(ArgumentNullException)
            {
                return true;
            }

        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            try
            {
                if (_lijnen.ElementAt(0) == null)
                {
                    _lijnen.AddFirst(lijn);
                }
                else
                {
                    Console.WriteLine("Lijn niet toegevoegd, positie is al vol");
                }
            }
            catch(ArgumentNullException)
            {
                _lijnen.AddFirst(lijn);
            }

        }

        public void VerschuifLijnen()
        {
            for (int i = 0; i < 10; i++)
            {
                Lijn lijn1 = _lijnen.ElementAt(i);
                if (i != 9)
                {
                    _lijnen.AddAfter(_lijnen.Find(lijn1), lijn1);
                    _lijnen.Remove(_lijnen.Find(lijn1));
                }
                if (i == 9)
                {
                    _lijnen.AddFirst(lijn1);
                    _lijnen.RemoveLast();
                }
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            Lijn lijn2 = _lijnen.Last();
            if (lijn2 != null)
            {
                _lijnen.RemoveLast();
                return lijn2;
            }
            else
            {
                return null;
            }
        }

        public string ToString()
        {
            string resultaat = "";
            for (int i = 0; i < 10; i++)
            {
                Lijn lijn1 = _lijnen.ElementAt(i);
                if (lijn1 != null)
                {
                    resultaat += i + "|";
                }
                else
                {

                }

            }
            int aantal = resultaat.Length - 1;
            resultaat.Remove(aantal, 1);
            return resultaat;
        }
        public static void TestOpdracht2()
        {
            Lijn lijn3 = new Lijn(0);
            Lijn lijn4 = new Lijn(1);
            Kabel kabel = new Kabel();
            Console.WriteLine(kabel);
            kabel.IsStartPositieLeeg();
            kabel.NeemLijnInGebruik(lijn3);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn4);
            Console.WriteLine(kabel);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            Console.WriteLine(kabel);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerwijderLijnVanKabel();
            kabel.VerschuifLijnen();
            kabel.VerwijderLijnVanKabel();
            kabel.VerschuifLijnen();
            Console.WriteLine(kabel);
        }
    }
}
