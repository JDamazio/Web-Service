using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Application.DTOs
{
	public class ClienteDTO
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "O nomé é obrigatório")]
		[MinLength(2)]
		[MaxLength(150)]
        public string Nome { get; set; }
		[Required(ErrorMessage = "O documento é obrigatório")]
		[MinLength(7)]
		[MaxLength(20)]
		public string Documento { get; set; }
		[Required(ErrorMessage = "O email é obrigatório")]
		[MinLength(10)]
		[MaxLength(200)]
		public string Email { get; set; }
		[Required(ErrorMessage = "O telefone é obrigatório")]
		[MinLength(8)]
		[MaxLength(15)]
		public string Telefone { get; set; }
		[Required(ErrorMessage = "A data de nascimento é obrigatório")]
		public DateTime DataNascimento { get; set; }
	}
}
