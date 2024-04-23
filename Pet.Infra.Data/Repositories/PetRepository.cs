using Microsoft.EntityFrameworkCore;
using Pet.Domain.Entities;
using Pet.Domain.Interfaces;
using Pet.Infra.Data.Context;

namespace Pet.Infra.Data.Repositories
{
	public class PetRepository : IPetRepository
	{
		private ApplicationDbContext _context;
		public PetRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Pets> CreateAsync(Pets pets)
		{
			_context.Add(pets);
			await _context.SaveChangesAsync();
			return pets;
		}

		public async Task<Pets> GetByIdAsync(int? id)
		{
			return await _context.Pets.FindAsync(id);
		}

		public async Task<Pets> GetPetClienteAsync(int? id)
		{
			return await _context.Pets.Include(c => c.ClienteId).SingleOrDefaultAsync(p => p.Id == id);
		}

		public async Task<IEnumerable<Pets>> GetPetsAsync()
		{
			return await _context.Pets.ToListAsync();

		}

		public async Task<Pets> RemoveAsync(Pets pets)
		{
			_context.Remove(pets);
			await _context.SaveChangesAsync();
			return pets;
		}

		public async Task<Pets> UpdateAsync(Pets pets)
		{
			_context.Update(pets);
			await _context.SaveChangesAsync();
			return pets;
		}
	}
}
