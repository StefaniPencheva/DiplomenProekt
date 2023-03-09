using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteFurniture.Models.Product
{
    public class ProductIndexVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string ProductName { get; set; }

        public int BrandId { get; set; }
        [Display(Name = "Марка")]
        public string BrandName { get; set; }

        public int CategoryId { get; set; }
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }

        [Display(Name = "Изображение")]
        public string Picture { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Отстъпка")]
        public decimal Discount { get; set; }
    }
}
