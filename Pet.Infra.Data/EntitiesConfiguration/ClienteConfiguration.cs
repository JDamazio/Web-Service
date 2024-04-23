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
	public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Nome).HasMaxLength(150).IsRequired();
			builder.Property(x => x.Documento).HasMaxLength(20).IsRequired();
			builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
			builder.Property(x => x.Telefone).HasMaxLength(15).IsRequired();
			builder.Property(x => x.DataNascimento).IsRequired();
		}
	}
}
