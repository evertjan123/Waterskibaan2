﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public interface Iwachtrij
    {
        void SporterNeemPlaatsInRij(Sporter sporter);
         List<Sporter> GetAlleSporters();
        List<Sporter> SportersVerlatenRij(int aantal);
    }
}
