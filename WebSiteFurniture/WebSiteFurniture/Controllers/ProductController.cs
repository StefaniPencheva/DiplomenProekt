using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSiteFurniture.Abstraction;
using WebSiteFurniture.Entities;
using WebSiteFurniture.Models.Brand;
using WebSiteFurniture.Models.Category;
using WebSiteFurniture.Models.Product;

namespace WebSiteFurniture.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;

        public ProductController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
            this._brandService = brandService;
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var product = new ProductCreateVM();
            product.Brands = _brandService.GetBrands()
            .Select(x => new BrandPairVM()
            {
                Id = x.Id,
                Name = x.BrandName
            }).ToList();
            product.Categories = _categoryService.GetCategories()
            .Select(x => new CategoryPairVM()
            {
                Id = x.Id,
                Name = x.CategoryName
            }).ToList();
            return View(product);
        }
        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ProductCreateVM product)
        {
            if (ModelState.IsValid)
            {
                var createdId = _productService.Create(product.ProductName, product.BrandId,
                                                       product.CategoryId, product.Description, product.Picture,
                                                       product.Quantity, product.Price,
                                                       product.Discount);
                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        // GET: ProductController/Index=All
        [AllowAnonymous]
        public ActionResult Index(string searchStringCategoryName, string searchStringBrandName)
        {
            List<ProductIndexVM> products = _productService.GetProducts(searchStringCategoryName, searchStringBrandName)
            .Select(product => new ProductIndexVM()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                BrandName = product.Brand.BrandName,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.CategoryName,
                Picture = product.Picture,
                Quantity = product.Quantity,
                Price = product.Price,
                Discount = product.Discount

            }).ToList();
            return this.View(products);
        }
        [AllowAnonymous]
        public ActionResult LivingRoom()
        {
            //  var products = _productService.GetProducts(searchStringCategoryName, searchStringBrandName).Where(x => x.Category.CategoryName == "Всекидневна").ToList();

            List<ProductIndexVM> products = _productService.GetProducts()
            .Select(product => new ProductIndexVM()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                BrandName = product.Brand.BrandName,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.CategoryName,
                Picture = product.Picture,
                Quantity = product.Quantity,
                Price = product.Price,
                Discount = product.Discount

            }).Where(x=>x.CategoryName== "Всекидневна").ToList();
          
            return this.View(products);
        }
        [AllowAnonymous]
        public ActionResult BedRoom()
        {
            //  var products = _productService.GetProducts(searchStringCategoryName, searchStringBrandName).Where(x => x.Category.CategoryName == "Всекидневна").ToList();

            List<ProductIndexVM> products = _productService.GetProducts()
            .Select(product => new ProductIndexVM()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                BrandName = product.Brand.BrandName,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.CategoryName,
                Picture = product.Picture,
                Quantity = product.Quantity,
                Price = product.Price,
                Discount = product.Discount

            }).Where(x => x.CategoryName == "Спалня").ToList();

            return this.View(products);
        }
        [AllowAnonymous]
        public ActionResult BathRoom()
        {
            //  var products = _productService.GetProducts(searchStringCategoryName, searchStringBrandName).Where(x => x.Category.CategoryName == "Всекидневна").ToList();

            List<ProductIndexVM> products = _productService.GetProducts()
            .Select(product => new ProductIndexVM()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                BrandName = product.Brand.BrandName,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.CategoryName,
                Picture = product.Picture,
                Quantity = product.Quantity,
                Price = product.Price,
                Discount = product.Discount

            }).Where(x => x.CategoryName == "Баня").ToList();

            return this.View(products);
        }

        // GET: ProductController/Edit
        public IActionResult Edit(int id)
        {
            Product product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            ProductEditVM updatedProduct = new ProductEditVM()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                //BrandName = product.Brand.BrandName,
                CategoryId = product.CategoryId,
                //CategoryName = product.Category.CategoryName,
                Description = product.Description,
                Picture = product.Picture,
                Quantity = product.Quantity,
                Price = product.Price,
                Discount = product.Discount
            };
            updatedProduct.Brands = _brandService.GetBrands()
              .Select(b => new BrandPairVM()
              {
                  Id = b.Id,
                  Name = b.BrandName
              })
            .ToList();

            updatedProduct.Categories = _categoryService.GetCategories()
              .Select(c => new CategoryPairVM()
              {
                  Id = c.Id,
                  Name = c.CategoryName
              })
            .ToList();
            return View(updatedProduct);
        }
        // GET: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEditVM product)
        {
            {
                if (ModelState.IsValid)
                {
                    var updated = _productService.Update(id, product.ProductName, product.BrandId,
                                                            product.CategoryId, product.Description,product.Picture,
                                                            product.Quantity, product.Price, product.Discount);
                    if (updated)
                    {
                        return this.RedirectToAction("Index");
                    }
                }
                return View(product);
            }
        }

        // GET: ProductController/Details
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }
            ProductDetailsVM product = new ProductDetailsVM()
            {
                Id = item.Id,
                ProductName = item.ProductName,
                BrandId = item.BrandId,
                BrandName = item.Brand.BrandName,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.CategoryName,
                Description = item.Description,
                Picture = item.Picture,
                Quantity = item.Quantity,
                Price = item.Price,
                Discount = item.Discount
            };
            return View(product);
        }

        // GET: ProductController/Delete
        public IActionResult Delete(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }
            ProductDeleteVM product = new ProductDeleteVM()
            {
                Id = item.Id,
                ProductName = item.ProductName,
                BrandId = item.BrandId,
                BrandName = item.Brand.BrandName,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.CategoryName,
                Description = item.Description,
                Picture = item.Picture,
                Quantity = item.Quantity,
                Price = item.Price,
                Discount = item.Discount
            };
            return View(product);
        }
        // GET: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {

            var deleted = _productService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("Success");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
