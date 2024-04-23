using MediatR;
using Pet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Application.PetCQRS.Commands
{
	public class PetRemoveCommand : IRequest<Pets>
	{
        public int Id { get; set; }

        public PetRemoveCommand(int id)
        {
           Id = id;
        }
    }
}
