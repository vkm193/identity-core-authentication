using Microsoft.EntityFrameworkCore;
using AuthDemo.Data.Models;
using AuthDemo.Data.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AuthDemo.Data.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        protected AuthDemoDBContext context;
        private readonly UserManager<User> userManager;

        public UserRepository(AuthDemoDBContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public User GetById(string id)
        {
            User user = context.Users.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
            return user;
        }
        public List<User> GetAll()
        {
            List<User> userList = context.Users.Where(x => x.IsActive).ToList();
            return userList;
        }

        public void Save(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            User userInDb = context.Users.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
            userInDb.IsActive = false;
            context.SaveChanges();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

    }
}
