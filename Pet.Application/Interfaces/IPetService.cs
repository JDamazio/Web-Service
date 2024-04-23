using Pet.Application.DTOs;
using Pet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Application.Interfaces
{
	public interface IPetService
	{
		Task<IEnumerable<PetDTO>> GetPets();
		Task<PetDTO> GetById(int? id);

		Task Add(PetDTO petDTO);
		Task Update(PetDTO petDTO);
		Task Remove(int? id);
	}
}
