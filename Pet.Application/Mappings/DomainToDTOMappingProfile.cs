using AutoMapper;
using Pet.Application.DTOs;
using Pet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Application.Mappings
{
	public class DomainToDTOMappingProfile : Profile
	{
        public DomainToDTOMappingProfile()
        {
            CreateMap<Cliente,ClienteDTO>().ReverseMap();
			CreateMap<Pets, PetDTO>().ReverseMap();
		}
	}
}
