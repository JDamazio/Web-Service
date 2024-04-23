using Pet.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Application.Interfaces
{
	public interface IClienteService
	{
		Task<IEnumerable<ClienteDTO>> GetClientes();
		Task<ClienteDTO> GetById(int? id);
		Task Add(ClienteDTO clienteDTO);
		Task Update(ClienteDTO clienteDTO);
		Task Remove(int? id);

	}
}
