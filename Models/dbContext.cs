using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuanLyBanHangAPI.Models
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<Combo> Combos { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=db.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Cart");
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.ToTable("Catalog");

                entity.Property(e => e.Catalog1).HasColumnName("Catalog");
            });

            modelBuilder.Entity<Combo>(entity =>
            {
                entity.ToTable("Combo");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.DateOfBirth).HasColumnType("NUMERIC");

                entity.Property(e => e.Gender).HasColumnType("NUMERIC");

                entity.Property(e => e.IsNew).HasColumnType("NUMERIC");

                entity.Property(e => e.JoinDate).HasColumnType("NUMERIC");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.DateOfBirth).HasColumnType("NUMERIC");

                entity.Property(e => e.Gender).HasColumnType("NUMERIC");

                entity.Property(e => e.JoinDate).HasColumnType("NUMERIC");

                entity.Property(e => e.Role).HasColumnType("NUMERIC");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.CreateAt).HasColumnType("NUMERIC");

                entity.Property(e => e.ShipDate).HasColumnType("NUMERIC");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("InvoiceDetail");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductDetail");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Storage");

                entity.Property(e => e.ExportDate).HasColumnType("NUMERIC");

                entity.Property(e => e.ImportDate).HasColumnType("NUMERIC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
