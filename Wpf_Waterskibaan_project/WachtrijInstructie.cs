using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    public class WachtrijInstructie : IWachtrij
    {
        public int MAX_LENGTE_RIJ = 100;
        public Queue<Sporter> InstructieQueue;
        public InstructieGroep instructieGroep;
        public WachtrijStarten wachtrijStarten;
        public WachtrijInstructie(Game game, InstructieGroep instructie, WachtrijStarten wachts)
        {
            InstructieQueue = new Queue<Sporter>();
            game.instructieAfgelopen += new Game.InstructieAfgelopenHandler(HandleInstructieAfgelopen);
            game.NieuweBezoeker += new Game.NieuweBezoekerHandler(HandleNieuweBezoeker);
            instructieGroep = instructie;
            wachtrijStarten = wachts;
        }
        public void HandleInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            List<Sporter> startSporters = instructieGroep.SportersVerlatenRij(args.AantalSporters);
            foreach (Sporter sp in startSporters)
            {
                wachtrijStarten.SporterNeemPlaatsInRij(sp);
            }
            List<Sporter> wachtrijSporters = SportersVerlatenRij(args.AantalSporters);
            foreach (Sporter sp in wachtrijSporters)
            {
                instructieGroep.SporterNeemPlaatsInRij(sp);
            }
        }
        public void HandleNieuweBezoeker(NieuweBezoekerArgs args)
        {
            Sporter sp = args.Sporter;
            if (InstructieQueue.Count() < MAX_LENGTE_RIJ)
            {
                InstructieQueue.Enqueue(sp);1
            }
        }

        public List<Sporter> GetAlleSporters()
        {
            Queue<Sporter> InstructieQueueAlleSporters = new Queue<Sporter>(InstructieQueue);
            List<Sporter> AlleSportersWachtInstructie = new List<Sporter>();
            for (int i = 0; i < InstructieQueue.Count; i++)
            {
                Sporter sp = InstructieQueueAlleSporters.Dequeue();
                AlleSportersWachtInstructie.Add(sp);
            }
            return AlleSportersWachtInstructie;
        }

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            InstructieQueue.Enqueue(sporter);
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> VerlatenSportersWachtInstructie = new List<Sporter>();
            for (int i = 0; i < aantal; i++)
            {
                if (InstructieQueue.Count() != 0)
                {
                    Sporter sp = InstructieQueue.Dequeue();
                    VerlatenSportersWachtInstructie.Add(sp);
                }
            }
            return VerlatenSportersWachtInstructie;

        }
        public override string ToString()
        {
            return $"Aantal sporters in de rij: {InstructieQueue.Count()}";
        }
    }
}
