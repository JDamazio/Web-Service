using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pet.Application.Interfaces;
using Pet.Application.Mappings;
using Pet.Application.Services;
using Pet.Domain.Account;
using Pet.Domain.Interfaces;
using Pet.Infra.Data.Context;
using Pet.Infra.Data.Identity;
using Pet.Infra.Data.Repositories;

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

			services.AddIdentity<ApplicationUser, IdentityRole>()
					.AddEntityFrameworkStores<ApplicationDbContext>()
					.AddDefaultTokenProviders();

			services.AddScoped<IClienteRepository, ClienteRepository>();
			services.AddScoped<IPetRepository, PetRepository>();

			services.AddScoped<IClienteService, ClienteService>();
			services.AddScoped<IPetService, PetService>();

			services.AddScoped<IAuthenticate, AuthenticateService>();
			services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

			services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

			var myhandlers = AppDomain.CurrentDomain.Load("Pet.Application");
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));

			return services;
		}
	}
}
