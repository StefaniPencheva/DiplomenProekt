using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteFurniture.Models.Order
{
    public class OrderIndexVM
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Display(Name = "Дата на поръчка")]
        public string OrderDate { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Потребител")]
        public string User { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "Продукт")]
        public string Product { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Изображение")]
        public string Picture { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Отстъпка")]
        public decimal Discount { get; set; }

        [Display(Name = "Крайна цена")]
        public decimal TotalPrice { get; set; }
    }
}
