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
    public class UserRolesRepository : IUserRolesRepository
    {
        protected AuthDemoDBContext context;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRolesRepository(AuthDemoDBContext context, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.roleManager = roleManager;
        }
        public async Task<string> GetRoleIdByRole(IdentityRole role)
        {
            return await roleManager.GetRoleIdAsync(role);
        }
    }
}
