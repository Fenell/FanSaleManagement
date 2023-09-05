using FSM_Data.Entities;
using FSM_Data.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.TotalAmount).HasColumnType("Decimal(10,2)").IsRequired();
            builder.HasData(
                    new Order()
                    {
                        Id = new Guid("303623C2-6719-4E94-90AB-6F578FF47B9E"),
                        CustomerName = "Lê Xuân Minh Chiến",
                        Address = "Nghệ An",
                        PhoneNumber = "0866999999",
                        TotalAmount = 2890000,
                        Status = Status.Active,
                        CreatedAt = new DateTime(2023, 09, 04),
                        IsDeleted = true
                    },
                    new Order()
                    {
                        Id = new Guid("D7B51740-AD10-45A2-914A-8D6382C61434"),
                        CustomerName = "Mai Tuấn Đạt",
                        Address = "Thái Bình",
                        PhoneNumber = "1234567890",
                        TotalAmount = 1950000,
                        Status = Status.Active,
                        CreatedAt = new DateTime(2023, 08, 18),
                        IsDeleted = true
                    }
                );
        }
    }
}
