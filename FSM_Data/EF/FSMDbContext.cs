using FSM_Data.Configuration;
using FSM_Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSM_Data.Configuration.Authen;
using FSM_Data.Entities.Authen;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FSM_Data.EF
{
    public class FSMDbContext : IdentityDbContext<ApplicationUser>
    {
        public FSMDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AppUserRoles").HasKey(x=>new{x.RoleId, x.UserId});
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AppUserLogins").HasKey(x=>x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AppUserTokens").HasKey(x=>x.UserId);
        }
    }
}
