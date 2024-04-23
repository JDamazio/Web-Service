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
	public class PetRemoveCommandHandler : IRequestHandler<PetRemoveCommand,Pets>
	{
		private readonly IPetRepository _repository;
		public PetRemoveCommandHandler(IPetRepository petRepository)
		{
			_repository = petRepository;
		}

		public async Task<Pets> Handle(PetRemoveCommand request, CancellationToken cancellationToken)
		{
			var pet = await _repository.GetByIdAsync(request.Id);
			if (pet == null) 
			{
				throw new ApplicationException("Entity pet não encontrado.");
			}
			else
			{
				var result = await _repository.RemoveAsync(pet);
				return result;
			}
		}
	}
}
