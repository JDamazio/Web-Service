using AutoMapper;
using MediatR;
using Pet.Application.DTOs;
using Pet.Application.Interfaces;
using Pet.Application.PetCQRS.Commands;
using Pet.Application.PetCQRS.Queries;
using Pet.Domain.Entities;
using Pet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Application.Services
{
	public class PetService : IPetService
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public PetService(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		public async Task<IEnumerable<PetDTO>> GetPets()
		{
			var petsQuery = new GetPetsQuery();
			if (petsQuery == null)
				throw new Exception("Pets não encontrados");

			var result = await _mediator.Send(petsQuery);
			return _mapper.Map<IEnumerable<PetDTO>>(result);
		}

		public async Task<PetDTO> GetById(int? id)
		{
			var petByIdQuery = new GetPetByIdQuery(id.Value);
			if (petByIdQuery == null)
				throw new Exception("Pet não encontrado.");

			var result = await _mediator.Send(petByIdQuery);
			return _mapper.Map<PetDTO>(result);
		}

		public async Task Add(PetDTO petDTO)
		{
			var petCreateCommand = _mapper.Map<PetCreateCommand>(petDTO);
			await _mediator.Send(petCreateCommand);
		}

		public async Task Update(PetDTO petDTO)
		{
			var petUpdateCommand = _mapper.Map<PetUpdateCommand>(petDTO);
			await _mediator.Send(petUpdateCommand);
		}

		public async Task Remove(int? id)
		{
			var petRemoveCommand = new PetRemoveCommand(id.Value);
			if (petRemoveCommand == null) 
				throw new Exception();

			await _mediator.Send(petRemoveCommand);
		}
	}
}
