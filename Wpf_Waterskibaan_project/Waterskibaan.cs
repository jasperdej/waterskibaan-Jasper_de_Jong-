using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Wpf_Waterskibaan_project
{
    public class Waterskibaan
    {
        public Kabel kabel;
        public LijnVoorraad lijnVoorraad;

        public Waterskibaan(Game game)
        {
            kabel = new Kabel();
            lijnVoorraad = new LijnVoorraad();
            for (int i = 0; i < 15; i++)
            {
                Lijn nieuwLijn = new Lijn(0, null);
                lijnVoorraad.LijnToevoegenAanRij(nieuwLijn);
            }
            game.LijnenVerplaatst += HandleLijnenVerplaatst;
        }

        public void HandleLijnenVerplaatst(LijnenVerplaatstArgs args)
        {
            Sporter sporter = args.Sporter;
            VerplaatsKabel();
            SporterStart(sporter);
        }
        public void VerplaatsKabel()
        {
            kabel.VerschuifLijnen();
            Lijn laatsteLijn = kabel.VerwijderLijnVanKabel();
            lijnVoorraad.LijnToevoegenAanRij(laatsteLijn);
        }

        public void SporterStart(Sporter sp)
        {
            if (sp.Zwemvest != null && sp.Skies != null)
            {
                sp.KledingKleur = Color.FromRgb(0, 255, 0);
                if (kabel.IsStartPositieLeeg() == true)
                {
                    Lijn lijnStart = lijnVoorraad.VerwijderEersteLijn();
                    kabel.NeemLijnInGebruik(lijnStart);
                    Random rnd = new Random();
                    sp.AantalRondenNogTeGaan = rnd.Next(1, 3);
                }
            }
            else
            {
                throw new AttributeNullException();
            }
        }

        public override string ToString()
        {
            return $"{lijnVoorraad} {kabel}";
        }
    }
}
