using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Application.PetCQRS.Commands
{
	public class PetUpdateCommand : PetCommand
	{
        public int Id { get; set; }
    }
}
