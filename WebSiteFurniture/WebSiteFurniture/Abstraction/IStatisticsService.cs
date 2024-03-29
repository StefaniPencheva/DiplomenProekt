﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteFurniture.Abstraction
{
    public interface IStatisticsService
    {
        int CountProducts();
        int CountClients();
        int CountOrders();
        decimal SumOrders();
    }
}
