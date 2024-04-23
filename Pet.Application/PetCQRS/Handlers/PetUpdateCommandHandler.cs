using MediatR;
using Pet.Application.PetCQRS.Commands;
using Pet.Domain.Entities;
using Pet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Application.PetCQRS.Handlers
{
	public class PetUpdateCommandHandler : IRequestHandler<PetUpdateCommand,Pets>
	{
		private readonly IPetRepository _repository;
		public PetUpdateCommandHandler(IPetRepository petRepository)
		{
			_repository = petRepository;
		}

		public async Task<Pets> Handle(PetUpdateCommand request, CancellationToken cancellationToken)
		{
			var pet = await _repository.GetByIdAsync(request.Id);

			if (pet == null)
			{
				throw new ApplicationException("Entity pet não encontrado.");
			}
			else
			{
				pet.Update(request.Nome, request.Apelido, request.DataNascimento, request.ClienteId);

				return await _repository.UpdateAsync(pet);
			}
		}
	}
}
