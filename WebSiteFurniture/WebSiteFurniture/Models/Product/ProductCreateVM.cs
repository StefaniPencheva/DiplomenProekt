using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebSiteFurniture.Models.Brand;
using WebSiteFurniture.Models.Category;

namespace WebSiteFurniture.Models.Product
{
    public class ProductCreateVM
    {
        public ProductCreateVM()
        {
            Brands = new List<BrandPairVM>();
            Categories = new List<CategoryPairVM>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Име на продукт")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Марка")]
        public int BrandId { get; set; }
        public virtual List<BrandPairVM> Brands { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        public virtual List<CategoryPairVM> Categories { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Снимка")]
        public string Picture { get; set; }

        [Required]
        [Range(0, 5000)]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Отстъпка")]
        public decimal Discount { get; set; }
    }
}
