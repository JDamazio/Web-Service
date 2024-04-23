using Pet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Domain.Interfaces
{
	public interface IClienteRepository
	{
		Task<IEnumerable<Cliente>> GetClientesAsync();
		Task<Cliente> GetByIdAsync(int? id);
		Task<Cliente> CreateAsync(Cliente cliente);
		Task<Cliente> UpdateAsync(Cliente cliente);
		Task<Cliente> RemoveAsync(Cliente cliente);
	}
}
