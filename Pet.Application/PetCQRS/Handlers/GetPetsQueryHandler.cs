using MediatR;
using Pet.Application.PetCQRS.Queries;
using Pet.Domain.Entities;
using Pet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Application.PetCQRS.Handlers
{
	public class GetPetsQueryHandler : IRequestHandler<GetPetsQuery, IEnumerable<Pets>>
	{

		private readonly IPetRepository _repository;
		public GetPetsQueryHandler(IPetRepository petRepository)
		{
			_repository = petRepository;
		}

		public async Task<IEnumerable<Pets>> Handle(GetPetsQuery request, CancellationToken cancellationToken)
		{
			return await _repository.GetPetsAsync();
		}
	}
}
