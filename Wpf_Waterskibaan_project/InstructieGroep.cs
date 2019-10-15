using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    class InstructieGroep : IWachtrij
    {
        public int MAX_LENGTE_RIJ = 5;
        public Queue<Sporter> InstructieQueue = new Queue<Sporter>();

        public List<Sporter> GetAlleSporters()
        {
            Queue<Sporter> InstructieQueueAlleSporters = new Queue<Sporter>(InstructieQueue);
            List<Sporter> AlleSportersInstructie = new List<Sporter>();
            for (int i = 0; i < InstructieQueue.Count; i++)
            {
                Sporter sp = InstructieQueueAlleSporters.Dequeue();
                AlleSportersInstructie.Add(sp);
            }
            return AlleSportersInstructie;
        }

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            InstructieQueue.Enqueue(sporter);
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> VerlatenSportersInstructie = new List<Sporter>();
            for (int i = 0; i < aantal; i++)
            {
                Sporter sp = InstructieQueue.Dequeue();
                VerlatenSportersInstructie.Add(sp);
            }
            return VerlatenSportersInstructie;
        }

        public override string ToString()
        {
            return $"Aantal sporters in de rij: {InstructieQueue.Count()}";
        }
    }
}
