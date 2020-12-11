﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyBanHangAPI.Models;

namespace QuanLyBanHangAPI.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20201209074258_Products")]
    partial class Products
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("QuanLyBanHangAPI.Models.Cart", b =>
                {
                    b.Property<long?>("IdCustomer")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("IdProduct")
                        .HasColumnType("INTEGER");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("QuanLyBanHangAPI.Models.Catalog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Catalog1")
                        .HasColumnType("TEXT")
                        .HasColumnName("Catalog");

                    b.HasKey("Id");

                    b.ToTable("Catalog");
                });

            modelBuilder.Entity("QuanLyBanHangAPI.Models.Combo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discount")
                        .HasColumnType("TEXT");

                    b.Property<double?>("DiscountMoney")
                        .HasColumnType("REAL");

                    b.Property<string>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ListProduct")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<double?>("TotalMoney")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Combo");
                });

            modelBuilder.Entity("QuanLyBanHangAPI.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("DateOfBirth")
                        .HasColumnType("NUMERIC");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Gender")
                        .HasColumnType("NUMERIC");

                    b.Property<byte[]>("IsNew")
                        .HasColumnType("NUMERIC");

                    b.Property<byte[]>("JoinDate")
                        .HasColumnType("NUMERIC");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("QuanLyBanHangAPI.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("DateOfBirth")
                        .HasColumnType("NUMERIC");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Gender")
                        .HasColumnType("NUMERIC");

                    b.Property<byte[]>("JoinDate")
                        .HasColumnType("NUMERIC");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Role")
                        .HasColumnType("NUMERIC");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("QuanLyBanHangAPI.Models.Invoice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("CreateAt")
                        .HasColumnType("NUMERIC");

                    b.Property<string>("CustomerAddress")
                        .HasColumnType("TEXT");

                    b.Property<long?>("IdCustomer")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("IdShipper")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("ShipDate")
                        .HasColumnType("NUMERIC");

                    b.Property<double?>("TotalMoney")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("QuanLyBanHangAPI.Models.InvoiceDetail", b =>
                {
                    b.Property<long?>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("IdCombo")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("IdInvoice")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("IdProduct")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Price")
                        .HasColumnType("REAL");

                    b.ToTable("InvoiceDetail");
                });

            modelBuilder.Entity("QuanLyBanHangAPI.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("IdCatalog")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("QuanLyBanHangAPI.Models.ProductDetail", b =>
                {
                    b.Property<string>("Detail")
                        .HasColumnType("TEXT");

                    b.Property<long?>("IdProduct")
                        .HasColumnType("INTEGER");

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("QuanLyBanHangAPI.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("QuanLyBanHangAPI.Models.Storage", b =>
                {
                    b.Property<long?>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("ExportDate")
                        .HasColumnType("NUMERIC");

                    b.Property<long?>("IdProduct")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("ImportDate")
                        .HasColumnType("NUMERIC");

                    b.ToTable("Storage");
                });
#pragma warning restore 612, 618
        }
    }
}
