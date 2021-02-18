using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using News21.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News21.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<NewsInfo> NewsInfos { get; set; }
        public DbSet<NewsComment> NewsComments { get; set; }
    }
}
