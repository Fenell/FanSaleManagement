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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(
                new Brand()
                {
                    Id = new Guid("702C6882-8782-481B-8D80-E5FB054BBDB2"),
                    Name = "Panasonic"
                },
                new Brand()
                {
                    Id = new Guid("C579B0B0-3EB4-4052-868F-782A941E2A47"),
                    Name = "Kangaroo"
                }
              );
        }
    }
}
