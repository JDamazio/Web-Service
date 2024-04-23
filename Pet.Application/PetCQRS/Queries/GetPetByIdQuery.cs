using MediatR;
using Pet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Application.PetCQRS.Queries
{
	public class GetPetByIdQuery : IRequest<Pets>
	{
		public int Id { get; set; }
		public GetPetByIdQuery(int id)
		{
			Id = id;
		}
	}
}
