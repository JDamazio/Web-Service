using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pet.Domain.Interfaces;
using Pet.Infra.Data.Context;
using Pet.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Infra.IoC
{
	public static class DependencyInjection 
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
					b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
			});

			services.AddScoped<IClienteRepository, ClienteRepository>();
			services.AddScoped<IPetRepository, PetRepository>();

			return services;
		}
	}
}
