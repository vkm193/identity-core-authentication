using AuthDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthDemo.Data.Repositories.IRepository
{
    public interface IUserRepository
    {
        User GetById(string id);
        List<User> GetAll();
        void Save(User user);
        void Delete(string id);
        Task<User> GetUserByEmail(string email);
    }
}
