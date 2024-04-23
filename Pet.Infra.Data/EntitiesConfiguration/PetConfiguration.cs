using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Infra.Data.EntitiesConfiguration
{
	public class PetConfiguration : IEntityTypeConfiguration<Pets>
	{
		public void Configure(EntityTypeBuilder<Pets> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Nome).HasMaxLength(150).IsRequired();
			builder.Property(x => x.Apelido).HasMaxLength(50).IsRequired();
			builder.Property(x => x.DataNascimento).IsRequired();

			builder.HasOne(c => c.Cliente).WithMany(p => p.Pets).HasForeignKey(c => c.ClienteId);
		}
	}
}
