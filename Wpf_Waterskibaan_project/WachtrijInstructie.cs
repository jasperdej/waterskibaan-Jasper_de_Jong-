using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    class WachtrijInstructie : IWachtrij
    {
        public int MAX_LENGTE_RIJ = 100;
        public Queue<Sporter> InstructieQueue = new Queue<Sporter>();

        public List<Sporter> GetAlleSporters()
        {
             Queue<Sporter> InstructieQueueAlleSporters = new Queue<Sporter>(InstructieQueue);
            List<Sporter> AlleSportersWachtInstructie = new List<Sporter>();
            for(int i = 0; i < InstructieQueue.Count; i++)
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
            for(int i = 0; i < aantal; i++)
            {
                Sporter sp = InstructieQueue.Dequeue();
                VerlatenSportersWachtInstructie.Add(sp);
            }
            return VerlatenSportersWachtInstructie;

        }
        public override string ToString()
        {
            return $"Aantal sporters in de rij: {InstructieQueue.Count()}";
        }
    }
}
