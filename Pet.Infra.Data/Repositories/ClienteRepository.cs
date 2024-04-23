using Microsoft.EntityFrameworkCore;
using Pet.Domain.Entities;
using Pet.Domain.Interfaces;
using Pet.Infra.Data.Context;

namespace Pet.Infra.Data.Repositories
{
	public class ClienteRepository : IClienteRepository
	{
		private ApplicationDbContext _context;
		public ClienteRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Cliente> CreateAsync(Cliente cliente)
		{
			_context.Add(cliente);
			await _context.SaveChangesAsync();
			return cliente;
		}

		public async Task<Cliente> GetByIdAsync(int? id)
		{
			return await _context.Clientes.FindAsync(id);
		}

		public async Task<IEnumerable<Cliente>> GetClientesAsync()
		{
			return await _context.Clientes.ToListAsync();
		}

		public async Task<Cliente> RemoveAsync(Cliente cliente)
		{
			_context.Remove(cliente);
			await _context.SaveChangesAsync();
			return cliente;
		}

		public async Task<Cliente> UpdateAsync(Cliente cliente)
		{
			_context.Update(cliente);
			await _context.SaveChangesAsync();
			return cliente;
		}
	}
}
