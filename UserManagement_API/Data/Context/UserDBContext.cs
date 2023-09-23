using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagement_API.Data.Entities;

namespace UserManagement_API.Data.Context
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        
    }
}