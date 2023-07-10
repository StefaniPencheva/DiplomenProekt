using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteFurniture.Models.Order
{
    public class OrderConfirmVM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }

        public string User { get; set; }
        [Required]

        public int ProductId { get; set; }

        [Display(Name = "Име на продукт")]
        public string ProductName { get; set; }

        [Display(Name = "Изображение")]
        public string Picture { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
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
