﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    class WachtrijStarten : IWachtrij
    {
        public int MAX_LENGTE_RIJ = 20;
        public Queue<Sporter> StartQueue = new Queue<Sporter>();

        public List<Sporter> GetAlleSporters()
        {
            Queue<Sporter> StartQueueAlleSporters = new Queue<Sporter>(StartQueue);
            List<Sporter> AlleSportersStart = new List<Sporter>();
            for (int i = 0; i < StartQueue.Count; i++)
            {
                Sporter sp = StartQueueAlleSporters.Dequeue();
                AlleSportersStart.Add(sp);
            }
            return AlleSportersStart;
        }

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            StartQueue.Enqueue(sporter);
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> VerlatenSportersStart = new List<Sporter>();
            for (int i = 0; i < aantal; i++)
            {
                Sporter sp = StartQueue.Dequeue();
                VerlatenSportersStart.Add(sp);
            }
            return VerlatenSportersStart;
        }
    }
}
