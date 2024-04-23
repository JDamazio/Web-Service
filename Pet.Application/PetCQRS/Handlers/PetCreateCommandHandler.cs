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
	public class PetCreateCommandHandler : IRequestHandler<PetCreateCommand, Pets>
	{
		private readonly IPetRepository _repository;
        public PetCreateCommandHandler(IPetRepository petRepository)
        {
			_repository = petRepository;
		}
        public async Task<Pets> Handle(PetCreateCommand request, CancellationToken cancellationToken)
		{
			var pet = new Pets(request.Nome,request.Apelido,request.DataNascimento);

			if (pet == null)
			{
				throw new ApplicationException("Erro ao criar o entity de pet");
			}
			else
			{
				pet.ClienteId = request.ClienteId;
				return await _repository.CreateAsync(pet);
			}
		}
	}
}
