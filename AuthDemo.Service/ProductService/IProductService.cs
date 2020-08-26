using System;
using System.Collections.Generic;
using AuthDemo.Service.DTO;

namespace AuthDemo.Service.ProductService
{
    public interface IProductService
    {
        ProductDTO GetById(int id);
        List<ProductDTO> GetAll();
        List<ProductDTO> GetAll(string keyword);
        void Save(ProductDTO product);
        void Edit(ProductDTO product);
        void UpdatePrice(int id, double price);
        void Delete(int id);
    }
}
