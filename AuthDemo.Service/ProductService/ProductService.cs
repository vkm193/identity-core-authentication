using AuthDemo.Data.Models;
using AuthDemo.Data.Repositories.IRepository;
using AuthDemo.Service.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthDemo.Service.ProductService
{
    public class ProductService : IProductService
    {
        protected IProductRepository productRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<User> userManager;

        public ProductService(IProductRepository _productRepository, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            productRepository = _productRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public ProductDTO GetById(int id)
        {
            Product product = productRepository.GetById(id);
            return MapProductToProductModel(product);
        }

        public List<ProductDTO> GetAll()
        {
            List<Product> productList = productRepository.GetAll();
            List<ProductDTO> prodList = new List<ProductDTO>();
            foreach (var product in productList)
            {
                prodList.Add(MapProductToProductModel(product));
            }

            return prodList;
        }

        public List<ProductDTO> GetAll(string keyword)
        {
            List<Product> productList = productRepository.GetAll(keyword);
            List<ProductDTO> prodList = new List<ProductDTO>();
            foreach (var product in productList)
            {
                prodList.Add(MapProductToProductModel(product));
            }
            return prodList;
        }

        public async void Save(ProductDTO product)
        {
            productRepository.Save(await MapProductModelToProduct(product));
        }

        public async void Edit(ProductDTO product)
        {
            productRepository.Edit(await MapProductModelToProduct(product, false));
        }

        public void UpdatePrice(int id, double price)
        {
            Product product = productRepository.GetById(id);
            product.Price = price;
            product.SalePrice = price + ((price * 10) / 100);
            productRepository.Edit(product);
        }

        public void Delete(int id)
        {
            productRepository.Delete(id);
        }

        private ProductDTO MapProductToProductModel(Product product)
        {
            ProductDTO prod = new ProductDTO();
            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.Price = product.Price;
            prod.SalePrice = product.Price + ((product.Price * 10) / 100);
            prod.ImageUrl = product.ImageUrl;
            prod.IsActive = product.IsActive;
            return prod;
        }

        private async Task<Product> MapProductModelToProduct(ProductDTO product, bool isAdd = true)
        {
            Product productEntity = new Product();
            User user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            productEntity.Id = product.Id;
            productEntity.Name = product.Name;
            productEntity.Description = product.Description;
            productEntity.Price = product.Price;
            productEntity.SalePrice = product.Price + ((product.Price * 10) / 100);
            productEntity.ImageUrl = product.ImageUrl;
            productEntity.UpdatedOn = DateTime.Now;
            productEntity.IsActive = product.IsActive;
            if (isAdd)
            {
                productEntity.CreatedBy = await userManager.GetUserNameAsync(user);
                productEntity.CreatedOn = DateTime.Now;
            }
            else
            {
                productEntity.UpdatedBy = await userManager.GetUserNameAsync(user); ;
                productEntity.UpdatedOn = DateTime.Now; ;
            }
            return productEntity;
        }
    }
}
