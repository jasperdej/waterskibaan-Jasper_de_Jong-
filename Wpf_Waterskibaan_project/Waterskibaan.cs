using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    class Waterskibaan
    {
        Kabel kabel;
        LijnVoorraad lijnVoorraad;
        public Waterskibaan()
        {
            kabel = new Kabel();
            lijnVoorraad = new LijnVoorraad();
            for (int i = 0; i < 15; i++)
            {
                Lijn nieuwLijn = new Lijn(0);
                lijnVoorraad.LijnToevoegenAanRij(nieuwLijn);
            }
        }
        public void VerplaatsKabel()
        {
            kabel.VerschuifLijnen();
            Lijn laatsteLijn = kabel.VerwijderLijnVanKabel();
            lijnVoorraad.LijnToevoegenAanRij(laatsteLijn);
        }

        public void SporterStart(Sporter sp)
        {
            sp.KledingKleur = Red; //Later verbeteren
            if (kabel.IsStartPositieLeeg() == true)
            {
                Lijn lijnStart = lijnVoorraad.VerwijderEersteLijn();
                kabel.NeemLijnInGebruik(lijnStart);
                Random rnd = new Random();
                sp.AantalRondenNogTeGaan = rnd.Next(1, 3);
            }
        }

        public override string ToString()
        {
            return $"{lijnVoorraad} {kabel}";           
        }
    }
}
