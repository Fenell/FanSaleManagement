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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(
                new Category()
                {
                    Id = new Guid("70E4623B-10B3-4935-B51D-381D7596CDB5"),
                    Name = "Quạt Cây"
                },
                new Category()
                {
                    Id = new Guid("428FFDFB-22DF-4344-8298-C96975A3E832"),
                    Name = "Quạt điều hoà"
                }
              );
        }
    }
}
