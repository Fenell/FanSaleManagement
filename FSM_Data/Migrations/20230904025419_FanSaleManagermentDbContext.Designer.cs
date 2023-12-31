﻿// <auto-generated />
using System;
using FSM_Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FSM_Data.Migrations
{
    [DbContext(typeof(FSMDbContext))]
    [Migration("20230904025419_FanSaleManagermentDbContext")]
    partial class FanSaleManagermentDbContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FSM_Data.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Brand");

                    b.HasData(
                        new
                        {
                            Id = new Guid("702c6882-8782-481b-8d80-e5fb054bbdb2"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Panasonic",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("c579b0b0-3eb4-4052-868f-782a941e2a47"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Kangaroo",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("FSM_Data.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = new Guid("70e4623b-10b3-4935-b51d-381d7596cdb5"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Quạt Cây",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("428ffdfb-22df-4344-8298-c96975a3e832"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Quạt điều hoà",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("FSM_Data.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            Id = new Guid("303623c2-6719-4e94-90ab-6f578ff47b9e"),
                            Address = "Nghệ An",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerName = "Lê Xuân Minh Chiến",
                            IsDeleted = true,
                            PhoneNumber = "0866999999",
                            Status = 1,
                            TotalAmount = 2890000m
                        },
                        new
                        {
                            Id = new Guid("d7b51740-ad10-45a2-914a-8d6382c61434"),
                            Address = "Thái Bình",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerName = "Mai Tuấn Đạt",
                            IsDeleted = true,
                            PhoneNumber = "1234567890",
                            Status = 1,
                            TotalAmount = 1950000m
                        });
                });

            modelBuilder.Entity("FSM_Data.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail");

                    b.HasData(
                        new
                        {
                            Id = new Guid("14a3dd60-38fa-4151-9509-c335ee3a12c4"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = true,
                            OrderId = new Guid("303623c2-6719-4e94-90ab-6f578ff47b9e"),
                            Price = 2890000m,
                            ProductId = new Guid("31f9ee52-fd3b-4684-8755-834865609cc4"),
                            Quantity = 1
                        },
                        new
                        {
                            Id = new Guid("9c893da5-203a-4056-8eb2-6caf385187f9"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = true,
                            OrderId = new Guid("d7b51740-ad10-45a2-914a-8d6382c61434"),
                            Price = 1950000m,
                            ProductId = new Guid("b56cc91f-948f-494f-a4f6-e8b966c8e5cc"),
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("FSM_Data.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = new Guid("31f9ee52-fd3b-4684-8755-834865609cc4"),
                            BrandId = new Guid("702c6882-8782-481b-8d80-e5fb054bbdb2"),
                            CategoryId = new Guid("70e4623b-10b3-4935-b51d-381d7596cdb5"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Làm mát hiệu quả, tự động đảo chiều cho góc thổi rộng.\r\nKiểu dáng nhỏ gọn, trang nhã, chất liệu nhựa trơn bóng cao cấp.\r\nDiều khiển từ xa giúp điều chỉnh tốc độ gió, xoay chiều mà không phải di chuyển.",
                            IsDeleted = true,
                            Name = "F-409KBE",
                            Price = 2890000m
                        },
                        new
                        {
                            Id = new Guid("b56cc91f-948f-494f-a4f6-e8b966c8e5cc"),
                            BrandId = new Guid("c579b0b0-3eb4-4052-868f-782a941e2a47"),
                            CategoryId = new Guid("428ffdfb-22df-4344-8298-c96975a3e832"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Quạt điều hòa công suất 100 W, làm mát trên diện tích 25 - 30 m2.\r\nTặng kèm hộp đá khô làm mát giúp giảm nhiệt độ tốt hơn.\r\nDung tích bình chứa nước 30 lít, sử dụng liên tục 10 - 15 tiếng.\r\n3 mức gió tùy chỉnh, tiện lợi với 3 chế độ gió thường - ngủ- tự nhiên.",
                            IsDeleted = true,
                            Name = "KG50F62",
                            Price = 1950000m
                        });
                });

            modelBuilder.Entity("FSM_Data.Entities.OrderDetail", b =>
                {
                    b.HasOne("FSM_Data.Entities.Order", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FSM_Data.Entities.Product", "Products")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("FSM_Data.Entities.Product", b =>
                {
                    b.HasOne("FSM_Data.Entities.Brand", "Brands")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FSM_Data.Entities.Category", "Categorys")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brands");

                    b.Navigation("Categorys");
                });

            modelBuilder.Entity("FSM_Data.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FSM_Data.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FSM_Data.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("FSM_Data.Entities.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
