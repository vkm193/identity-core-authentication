using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthDemo.Data.Repositories.IRepository
{
    public interface IUserRolesRepository
    {
        Task<string> GetRoleIdByRole(IdentityRole role);
    }
}
