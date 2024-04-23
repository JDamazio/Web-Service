using MediatR;
using Pet.Application.PetCQRS.Queries;
using Pet.Domain.Entities;
using Pet.Domain.Interfaces;

namespace Pet.Application.PetCQRS.Handlers
{
	public class GetPetByIdQueryHandler : IRequestHandler<GetPetByIdQuery, Pets>
	{
		private readonly IPetRepository _repository;
		public GetPetByIdQueryHandler(IPetRepository petRepository)
		{
			_repository = petRepository;
		}

		public async Task<Pets> Handle(GetPetByIdQuery request, CancellationToken cancellationToken)
		{
			return await _repository.GetByIdAsync(request.Id);
		}
	}
}
