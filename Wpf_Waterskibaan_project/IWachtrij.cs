using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    interface IWachtrij //Kijk later naar abstracte klasse
    {
        void SporterNeemPlaatsInRij(Sporter sporter);

        List<Sporter> GetAlleSporters();

        List<Sporter> SportersVerlatenRij(int aantal);
    }
}
