using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSiteFurniture.Abstraction;
using WebSiteFurniture.Data;
using WebSiteFurniture.Entities;

namespace WebSiteFurniture.Services
{
    public class CategoryService:ICategoryService
    {
            private readonly ApplicationDbContext _context;

            public CategoryService(ApplicationDbContext context)
            {
                _context = context;
            }
            public List<Category> GetCategories()
            {
                List<Category> category = _context.Categories.ToList();
                return category;
            }

            public Category GetCategoryById(int categoryId)
            {
                return _context.Categories.Find(categoryId);
            }

            public List<Product> GetProductsByCategory(int categoryId)
            {
                return _context.Products
                    .Where(x => x.CategoryId == categoryId)
                    .ToList();
            }
    }
}

