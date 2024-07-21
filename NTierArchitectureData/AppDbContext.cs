using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NTierArchitectureData.Auth;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitectureData
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext([NotNull] DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<AnalyzeQueue>().HasIndex(p => new { p.ProcessingStartedAt, p.CreatedDate  }).IncludeProperties(p => p.Id)
            //        .HasSortOrder(new [] { SortOrder.Ascending, SortOrder.Ascending }) ;

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseNpgsql(
                    "Host=localhost;Port=5432;Username=postgres;Database=ecommerce;password=1234; Trust Server Certificate=true",
                    options => options.SetPostgresVersion(new Version(11, 13)));

                return new AppDbContext(optionsBuilder.Options);
            }
        }
    }
}
