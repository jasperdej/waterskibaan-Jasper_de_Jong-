using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Random rnd = new Random();

        public Waterskibaan(Game game)
        {
            kabel = new Kabel();
            lijnVoorraad = new LijnVoorraad();
            for (int i = 0; i < 15; i++)
            {
                Lijn nieuwLijn = new Lijn(0, null);
                lijnVoorraad.LijnToevoegenAanRij(nieuwLijn);
            }
            game.LijnenVerplaatst += new Game.LijnenVerplaatstHandler(HandleLijnenVerplaatst);
        }

        public void HandleLijnenVerplaatst(LijnenVerplaatstArgs args)
        {
            Sporter sporter = args.Sporter;
            VerplaatsKabel();
            if (sporter != null)
            {
                SporterStart(sporter);
            }
        }
        public void VerplaatsKabel()
        {
            kabel.VerschuifLijnen();
            Lijn laatsteLijn = kabel.VerwijderLijnVanKabel();
            if (laatsteLijn != null)
            {
                lijnVoorraad.LijnToevoegenAanRij(laatsteLijn);
            }
        }

        public void SporterStart(Sporter sp)
        {
            if (sp != null)
            {
                if (sp.Zwemvest != null && sp.Skies != null)
                {
                    if (kabel.IsStartPositieLeeg() == true)
                    {
                        Lijn lijnStart = lijnVoorraad.VerwijderEersteLijn();
                        lijnStart.SporterAanLijn = sp;
                        lijnStart.PositieOpDeKabel = 0;
                        kabel.NeemLijnInGebruik(lijnStart);
                        sp.AantalRondenNogTeGaan = rnd.Next(1, 3);
                    }
                }
                else
                {
                    throw new AttributeNullException();
                }

            }
        }

        public override string ToString()
        {
            return $"{lijnVoorraad} {kabel}";
        }
    }
}
