using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using framework_authentication.Models;

namespace framework_authentication.Data
{
    public class framework_authenticationContext : DbContext
    {
        public framework_authenticationContext (DbContextOptions<framework_authenticationContext> options)
            : base(options)
        {
        }

        public DbSet<framework_authentication.Models.Users> Users { get; set; }

        public DbSet<framework_authentication.Models.Token> Token { get; set; }
    }
}
