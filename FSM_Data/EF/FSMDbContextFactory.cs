using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Data.EF
{
    public class FSMDbContextFactory : IDesignTimeDbContextFactory<FSMDbContext>
    {
        public FSMDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

            var connectonString = configuration.GetConnectionString("FanSaleManagement");

            var optionsBuilder = new DbContextOptionsBuilder<FSMDbContext>();
            optionsBuilder.UseSqlServer(connectonString);

            return new FSMDbContext(optionsBuilder.Options);
        }
    }
}
