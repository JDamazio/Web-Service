using AutoMapper;
using Pet.Application.DTOs;
using Pet.Application.Interfaces;
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
		private IPetRepository _repository;
		private readonly IMapper _mapper;

		public PetService(IPetRepository repository, IMapper mapper)
		{
			_repository = repository ?? throw new ArgumentException(nameof(repository));
			_mapper = mapper;
		}

		public async Task<IEnumerable<PetDTO>> GetPets()
		{
			var petsEntity = await _repository.GetPetsAsync();
			return _mapper.Map<IEnumerable<PetDTO>>(petsEntity);
		}

		public async Task<PetDTO> GetById(int? id)
		{
			var petEntity = await _repository.GetByIdAsync(id);
			return _mapper.Map<PetDTO>(petEntity);
		}

		public async Task<PetDTO> GetPetCliente(int? id)
		{
			var petEntity = await _repository.GetPetClienteAsync(id);
			return _mapper.Map<PetDTO>(petEntity);
		}

		public async Task Add(PetDTO petDTO)
		{
			var petEntity = _mapper.Map<Pets>(petDTO);
			await _repository.CreateAsync(petEntity);
		}

		public async Task Update(PetDTO petDTO)
		{
			var petEntity = _mapper.Map<Pets>(petDTO);
			await _repository.UpdateAsync(petEntity);
		}

		public async Task Remove(int? id)
		{
			var petEntity = _repository.GetByIdAsync(id).Result;
			await _repository.RemoveAsync(petEntity);
		}
	}
}
