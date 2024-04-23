using MediatR;
using Pet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Application.PetCQRS.Commands
{
	public abstract class PetCommand : IRequest<Pets>
	{
		public string Nome { get; set; }
		public string? Apelido { get; set; }
		public DateTime DataNascimento { get; set; }
		public int ClienteId { get; set; }
	}
}
