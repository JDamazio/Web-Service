using AutoMapper;
using Pet.Application.DTOs;
using Pet.Application.Interfaces;
using Pet.Domain.Entities;
using Pet.Domain.Interfaces;

namespace Pet.Application.Services
{
	public class ClienteService : IClienteService
	{
		private IClienteRepository _repository;
		private readonly IMapper _mapper;

		public ClienteService(IClienteRepository repository, IMapper mapper)
		{
			_repository = repository ?? throw new ArgumentException(nameof(repository));
			_mapper = mapper;
		}

		public async Task<IEnumerable<ClienteDTO>> GetClientes()
		{
			var clientesEntity = await _repository.GetClientesAsync();
			return _mapper.Map<IEnumerable<ClienteDTO>>(clientesEntity);
		}

		public async Task<ClienteDTO> GetById(int? id)
		{
			var clienteEntity = await _repository.GetByIdAsync(id);
			return _mapper.Map<ClienteDTO>(clienteEntity);
		}

		public async Task Add(ClienteDTO clienteDTO)
		{
			var clienteEntity = _mapper.Map<Cliente>(clienteDTO);
			await _repository.CreateAsync(clienteEntity);
		}

		public async Task Update(ClienteDTO clienteDTO)
		{
			var clienteEntity = _mapper.Map<Cliente>(clienteDTO);
			await _repository.UpdateAsync(clienteEntity);
		}

		public async Task Remove(int? id)
		{
			//depois atualizar para desativar e não deletar
			var clienteEntity = _repository.GetByIdAsync(id).Result;
			await _repository.RemoveAsync(clienteEntity);
		}
	}
}
