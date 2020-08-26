using AuthDemo.Data.Models;
using AuthDemo.Data.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthDemo.Data.Repositories.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected AuthDemoDBContext context;
        public ProductRepository(AuthDemoDBContext context)
        {
            this.context = context;
        }

        public Product GetById(int id)
        {
            Product product = context.Products.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
            return product;
        }
        public List<Product> GetAll()
        {
            List<Product> productList = context.Products.Where(x => x.IsActive).ToList();
            return productList;
        }
        public List<Product> GetAll(string keyword)
        {
            List<Product> productList = context.Products.Where(x => (x.Name.Contains(keyword) || x.Description.Contains(keyword)) && x.IsActive).ToList();
            return productList;
        }
        public void Save(Models.Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }
        public void Edit(Models.Product product)
        {
            Product productInDb = context.Products.Where(x => x.Id == product.Id && x.IsActive).FirstOrDefault();
            productInDb.Name = product.Name;
            productInDb.Description = product.Description;
            productInDb.Price = product.Price;
            productInDb.SalePrice = product.SalePrice;
            productInDb.ImageUrl = product.ImageUrl;
            productInDb.CreatedBy = product.CreatedBy;
            productInDb.CreatedOn = product.CreatedOn;
            productInDb.UpdatedBy = product.UpdatedBy;
            productInDb.UpdatedOn = product.UpdatedOn;
            productInDb.IsActive = product.IsActive;
            context.SaveChanges();

        }
        public void Delete(int id)
        {
            Product productInDb = context.Products.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
            productInDb.IsActive = false;
            context.SaveChanges();
        }
    }
}
