using Pet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pet.Application.DTOs
{
	public class PetDTO
	{
        public int Id { get; set; }
		//[Required(ErrorMessage = "O nomé é obrigatório")]
		[MinLength(2)]
		[MaxLength(150)]
		public string Nome { get; private set; }
		//[Required(ErrorMessage = "O apelido é obrigatório")]
		[MinLength(3)]
		[MaxLength(50)]
		public string? Apelido { get; private set; }
		//[Required(ErrorMessage = "A data de nascimento é obrigatório")]
		public DateTime DataNascimento { get; private set; }
		[JsonIgnore]
        public Cliente Cliente { get; set; }
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }

    }
}
