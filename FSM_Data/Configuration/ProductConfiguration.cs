using FSM_Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(c => c.Brands).WithMany(c => c.Products).HasForeignKey(c => c.BrandId);
            builder.HasOne(c => c.Categorys).WithMany(c => c.Products).HasForeignKey(c => c.CategoryId);
            builder.Property(c => c.Price).HasColumnType("Decimal(10,2)").IsRequired();
            builder.HasData(
                    new Product()
                    {
                        Id = new Guid("31F9EE52-FD3B-4684-8755-834865609CC4"),
                        CategoryId = new Guid("70E4623B-10B3-4935-B51D-381D7596CDB5"),
                        BrandId = new Guid("702C6882-8782-481B-8D80-E5FB054BBDB2"),
                        Name = "F-409KBE",
                        Price = 2890000,
                        Description = "Làm mát hiệu quả, tự động đảo chiều cho góc thổi rộng.\r\nKiểu dáng nhỏ gọn, trang nhã, chất liệu nhựa trơn bóng cao cấp.\r\nDiều khiển từ xa giúp điều chỉnh tốc độ gió, xoay chiều mà không phải di chuyển.",
                        CreatedAt = new DateTime(2023, 09, 04),
                        IsDeleted = true
                    },
                    new Product()
                    {
                        Id = new Guid("B56CC91F-948F-494F-A4F6-E8B966C8E5CC"),
                        CategoryId = new Guid("428FFDFB-22DF-4344-8298-C96975A3E832"),
                        BrandId = new Guid("C579B0B0-3EB4-4052-868F-782A941E2A47"),
                        Name = "KG50F62",
                        Price = 1950000,
                        Description = "Quạt điều hòa công suất 100 W, làm mát trên diện tích 25 - 30 m2.\r\nTặng kèm hộp đá khô làm mát giúp giảm nhiệt độ tốt hơn.\r\nDung tích bình chứa nước 30 lít, sử dụng liên tục 10 - 15 tiếng.\r\n3 mức gió tùy chỉnh, tiện lợi với 3 chế độ gió thường - ngủ- tự nhiên.",
                        CreatedAt = new DateTime(2023, 08, 18),
                        IsDeleted = true
                    }
               );
        }
    }
}
