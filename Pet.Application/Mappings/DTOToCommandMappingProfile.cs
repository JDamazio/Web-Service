using AutoMapper;
using Pet.Application.DTOs;
using Pet.Application.PetCQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Application.Mappings
{
	public class DTOToCommandMappingProfile : Profile
	{
        public DTOToCommandMappingProfile()
        {
            CreateMap<PetDTO, PetCreateCommand>();
			CreateMap<PetDTO, PetUpdateCommand>();
		}
    }
}
