using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pet.Domain.Entities;
using Pet.Infra.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Infra.Data.Context
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pets> Pets { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}