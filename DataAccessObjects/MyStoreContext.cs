using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace DataAccessObjects
{
    public partial class MyStoreContext : DbContext
    {
        public MyStoreContext() { }

        public MyStoreContext(DbContextOptions<MyStoreContext> options)
       : base(options)
        {
        }

        public virtual DbSet<AccountMember> AccountMembers { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true).Build();
            return configuration["ConnectionStrings:DefaultConnectionStrings"];
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountMember>()
                .HasKey(a => a.MemberId);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.Property(e => e.ProductId).HasColumnName("ProductId");
                entity.Property(e => e.ProductName).HasMaxLength(50);
                entity.Property(e => e.UnitsInStock);
                entity.Property(e => e.UnitPrice);
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_CategoryId");
            });
        }

    }

}