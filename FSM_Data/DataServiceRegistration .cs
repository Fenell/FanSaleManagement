using FSM_Data.EF;
using FSM_Data.Entities.Authen;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FSM_Data;

public static class DataServiceRegistration
{
	public static IServiceCollection AddDataService(this IServiceCollection services ,IConfiguration configuration)
	{
		services.AddDbContext<FSMDbContext>(otp =>
			otp.UseSqlServer(configuration.GetConnectionString("FanSaleManagement")));

		services.AddIdentity<ApplicationUser, IdentityRole>()
			.AddEntityFrameworkStores<FSMDbContext>()
			.AddDefaultTokenProviders();

		return services;
	}
}