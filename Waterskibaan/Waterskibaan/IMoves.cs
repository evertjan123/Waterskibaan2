﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public  interface IMoves
    {
        string Naam { get; }
        int moves();
        int Jump();
        int Omdraaien();
        int OpEenBeen();
        int MetEenHand();
    }
}
