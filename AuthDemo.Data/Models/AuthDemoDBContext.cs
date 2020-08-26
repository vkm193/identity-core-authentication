using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthDemo.Data.Models
{
    public class AuthDemoDBContext : IdentityDbContext<User>
    {
        public AuthDemoDBContext(DbContextOptions<AuthDemoDBContext> options) : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }

    }
}
