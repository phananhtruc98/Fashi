// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DAL.Models.Interfaces;
using Attribute = DAL.Models.Attribute;

namespace DAL
{
    public class ApplicationDbContext: DbContext 
    {
        public string CurrentUserId { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }        
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetail { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Attribute> Attribute { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<PromotionMethod> PromotionMethod { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
                
            builder.Entity<User>().Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            builder.Entity<User>().Property(u => u.LastName).IsRequired().HasMaxLength(100);
            builder.Entity<User>().HasIndex(u => new { u.FirstName, u.LastName });
            builder.Entity<User>().Property(u => u.Email).HasMaxLength(100);
            builder.Entity<User>().Property(u => u.MobileNumber).IsUnicode(false).HasMaxLength(30);
            builder.Entity<User>().HasMany(u => u.Addresses).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            builder.Entity<User>().HasOne(u => u.Cart).WithOne(c => c.User).HasForeignKey<User>(u => u.CartId);
            builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId);

            builder.Entity<Address>().Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Address>().Property(a => a.Ward).HasMaxLength(100);
            builder.Entity<Address>().Property(a => a.District).HasMaxLength(100);
            builder.Entity<Address>().Property(a => a.City).HasMaxLength(100);
            builder.Entity<Address>().Property(a => a.Country).HasMaxLength(100);
            //builder.Entity<Address>().HasOne(a => a.User).WithMany(u => u.Addresses);

            builder.Entity<Banner>().Property(b => b.Name).IsRequired();

            builder.Entity<Category>().Property(c => c.Name).HasMaxLength(500);

            builder.Entity<PromotionMethod>().Property(c => c.Name).HasMaxLength(500);
            builder.Entity<PromotionMethod>().HasMany(pm => pm.Promotions).WithOne(p => p.PromotionMethod).HasForeignKey(p => p.PromotionMethodId);

            builder.Entity<Product>().Property(p => p.Name).HasMaxLength(500);
            builder.Entity<Product>().Property(p => p.Price).IsUnicode(false).HasMaxLength(500);
            builder.Entity<Product>().Property(p => p.Summary).HasMaxLength(500);

            builder.Entity<ProductCategory>().HasOne(pc => pc.Product).WithMany(p => p.ProductCategories).HasForeignKey(pc => pc.ProductId);
            builder.Entity<ProductCategory>().HasOne(pc => pc.Category).WithMany(p => p.ProductCategories).HasForeignKey(pc => pc.CategoryId);

            builder.Entity<Attribute>().Property(a => a.Name).IsRequired();

            builder.Entity<Attribute>().HasMany(pd => pd.ProductDetails).WithOne(a => a.Attribute).HasForeignKey(a => a.AttributeId);

            builder.Entity<CartDetails>().HasOne(cd => cd.Cart).WithMany(c => c.CartDetails).HasForeignKey(cd => cd.CartId);
            builder.Entity<CartDetails>().HasOne(cd => cd.ProductDetails).WithMany(pd => pd.CartDetails).HasForeignKey(cd => cd.ProductDetailsId);

            builder.Entity<Promotion>().Property(c => c.Name).HasMaxLength(500);

            builder.Entity<OrderDetails>().HasOne(od => od.Order).WithMany(c => c.OrderDetails).HasForeignKey(od => od.OrderId);
            builder.Entity<OrderDetails>().HasOne(od => od.ProductDetails).WithMany(c => c.OrderDetails).HasForeignKey(od => od.ProductDetailsId);
            builder.Entity<OrderDetails>().HasOne(od => od.Promotion).WithMany(p => p.OrderDetails).HasForeignKey(od => od.PromotionId);
            
            builder.Entity<UserType>().HasMany(up => up.Users).WithOne(u => u.UserType).HasForeignKey(up => up.UserTypeId);
        }




        public override int SaveChanges()
        {
            UpdateAuditEntities();
            return base.SaveChanges();
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateAuditEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        private void UpdateAuditEntities()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));


            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                DateTime now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = CurrentUserId;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = CurrentUserId;
            }
        }
    }
}
