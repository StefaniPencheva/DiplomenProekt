using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSiteFurniture.Entities;

namespace WebSiteFurniture.Abstraction
{
    public interface IProductService
    {
        bool Create(string name, int brandId,
            int caqtegoryId, string description, string picture, int quantity, decimal price, decimal discount);
        bool Update(int productId, string name, int brandId, int categoryId, string description, string picture, int quantity, decimal price, decimal discount);

        List<Product> GetProduct();
        Product GetProductById(int productId);
        bool RemoveById(int productId);
        List<Product> GetProducts(string searchStringCategoryName, string searchStringBrandName);
    }
}
