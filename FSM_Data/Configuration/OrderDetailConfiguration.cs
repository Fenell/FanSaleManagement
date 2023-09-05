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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(c => c.Products).WithMany(c => c.OrderDetails).HasForeignKey(c => c.ProductId);
            builder.HasOne(c => c.Orders).WithMany(c => c.OrderDetails).HasForeignKey(c => c.OrderId);
            builder.Property(c => c.Price).HasColumnType("Decimal(10,2)").IsRequired();
            builder.HasData(
                    new OrderDetail()
                    {
                        Id = new Guid("14A3DD60-38FA-4151-9509-C335EE3A12C4"),
                        ProductId = new Guid("31F9EE52-FD3B-4684-8755-834865609CC4"),
                        OrderId = new Guid("303623C2-6719-4E94-90AB-6F578FF47B9E"),
                        Quantity = 1,
                        Price = 2890000,
                        CreatedAt = new DateTime(2023, 09, 04),
                        IsDeleted = true
                    },
                    new OrderDetail()
                    {
                        Id = new Guid("9C893DA5-203A-4056-8EB2-6CAF385187F9"),
                        ProductId = new Guid("B56CC91F-948F-494F-A4F6-E8B966C8E5CC"),
                        OrderId = new Guid("D7B51740-AD10-45A2-914A-8D6382C61434"),
                        Quantity = 1,
                        Price = 1950000,
                        CreatedAt = new DateTime(2023, 08, 18),
                        IsDeleted = true
                    }
                );
        }
    }
}
