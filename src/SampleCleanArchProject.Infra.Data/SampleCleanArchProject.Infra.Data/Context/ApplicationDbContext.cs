using Microsoft.EntityFrameworkCore;
using SampleCleanArchProject.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SampleCleanArchProject.Infra.Data.Identity;

namespace SampleCleanArchProject.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}