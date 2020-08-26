using AuthDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace AuthDemo.Data.Repositories.IRepository
{
    public interface IProductRepository
    {
        Product GetById(int id);
        List<Product> GetAll();
        List<Product> GetAll(string keyword);
        void Save(Product product);
        void Edit(Product product);
        void Delete(int id);
    }
}
