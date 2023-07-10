using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteFurniture.Models.Statistics
{
    public class StatisticsVM
    {
        [Display(Name = "Брой клиенти")]
        public int CountClients { get; set; }
        [Display(Name = "Брой продукти")]
        public int CountProducts{ get; set; }
        [Display(Name = "Брой поръчки")]
        public int CountOrders { get; set; }

        [Display(Name = "Обща сума")]
        public decimal SumOrders { get; set; }
    }
}
