using Pet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Domain.Interfaces
{
	public interface IPetRepository
	{
		Task<IEnumerable<Pets>> GetPetsAsync();
		Task<Pets> GetByIdAsync(int? id);
		Task<Pets> CreateAsync(Pets pets);
		Task<Pets> UpdateAsync(Pets pets);
		Task<Pets> RemoveAsync(Pets pets);
	}
}
