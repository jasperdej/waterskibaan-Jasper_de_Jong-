using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    public class Kabel
    {
        public LinkedList<Lijn> _lijnen;

        public Kabel()
        {
            /*Lijn[] startLijnen = new Lijn[9];*/
            _lijnen = new LinkedList<Lijn>();
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
            catch (ArgumentNullException)
            {
                return true;
            }

        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            try
            {
                if (_lijnen.First.Value == null)
                {
                    _lijnen.AddFirst(lijn);
                }
                else
                {
                    Trace.WriteLine("Lijn niet toegevoegd, positie is al vol");
                }
            }
            catch (ArgumentNullException)
            {
                _lijnen.AddFirst(lijn);
            }
            Trace.WriteLine("Lijn toegevoegd");

        }

        public void VerschuifLijnen()
        {
            Lijn[] lArray = new Lijn[11];
            _lijnen.CopyTo(lArray, 0);
            Lijn[] lArrayTijdelijk = new Lijn[10];
            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                if (lArray[i] != null)
                {
                    Lijn lijn1 = lArray[i];
                    if (i != 9)
                    {
                        lArrayTijdelijk[i + 1] = lijn1;
                        lijn1.PositieOpDeKabel += 1;
                    }
                    if (i == 9)
                    {
                        lijn1.SporterAanLijn.AantalRondenNogTeGaan--;
                        if (lijn1.SporterAanLijn.AantalRondenNogTeGaan == 0)
                        {
                            VerwijderLijnVanKabel();
                        }
                        else
                        {
                            lArrayTijdelijk[0] = lijn1;
                            lijn1.PositieOpDeKabel = 0;
                        }
                    }
                }
            }
            Trace.WriteLine("Lijnen bewogen");
            _lijnen = new LinkedList<Lijn>(lArrayTijdelijk);
        }

        public Lijn VerwijderLijnVanKabel()
        {
            Lijn lijn2 = _lijnen.Last();
            if (lijn2 != null && lijn2.SporterAanLijn.AantalRondenNogTeGaan == 1)
            {
                _lijnen.RemoveLast();
                return lijn2;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            string resultaat = "";
            for (int i = 0; i < 9; i++)
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
            if (resultaat != "")
            {
                resultaat = resultaat.Remove(resultaat.Length - 1);
            }

            return resultaat;
        }
    }
}
