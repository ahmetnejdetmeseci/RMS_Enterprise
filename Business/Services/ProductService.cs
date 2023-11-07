using Business.Models;
using Business.Results;
using Business.Results.Basis;
using Business.Services.Basis;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductService : IProductService
    {

        private readonly Db _db;

        public ProductService(Db db)
        {
            _db = db;
        }

        public Result Add(ProductModel model)
        {
            if(_db.Products.Any(p => p.ProductName.ToUpper() == model.ProductName.ToUpper().Trim()))
            {
                return new FailureResult("You already have same product");
            }

            Product product = new Product()
            {
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                Price = model.Price,
                Quantity = model.Quantity,
            };

            _db.Products.Add(product);
            _db.SaveChanges();

            return new SuccessResult("Product added successfully");
        }

        public Result Delete(ProductModel model)
        {
            var product = _db.Products.SingleOrDefault(p => p.Id == model.Id);

            if(product == null)
            {
                return new FailureResult("No such product!");
            }

            _db.Products.Remove(product);
            _db.SaveChanges();
            return new SuccessResult("product deleted successfully");

        }

        public IQueryable<ProductModel> Query()
        {
            return _db.Products.OrderBy(p => p.ProductName).Select(p => new ProductModel
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Price = p.Price,
                ProductDescription = p.ProductDescription,
                Quantity = p.Quantity
            });
        }

        public Result Update(ProductModel model)
        {
            List<Product> existingProduct = _db.Products.ToList();
            if(existingProduct.Any(p => p.ProductName.Equals(model.ProductName.Trim(), StringComparison.OrdinalIgnoreCase) && p.Id != model.Id))
            {
                return new FailureResult("Product already exists");
            }

            var product = _db.Products.SingleOrDefault(p => p.Id == model.Id);

            if(product is not null)
            {
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.Quantity = model.Quantity;
                product.ProductDescription = model.ProductDescription;
                
                _db.Products.Update(product);

                _db.SaveChanges();
              
            }

            return new SuccessResult("Product Updated successfully");

        }
    }
}
