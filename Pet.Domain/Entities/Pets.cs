using Pet.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Domain.Entities
{
	public sealed class Pets : Entity
	{
		public string Nome { get; private set; }
		public string? Apelido { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

		public Pets(string nome, string? apelido, DateTime dataNascimento)
		{
			ValidateDomain(nome, apelido, dataNascimento);
		}
		public Pets(int id, string nome, string? apelido, DateTime dataNascimento)
		{
			DomainExceptionValidation.When(id < 0, "Id inválido");
			Id = id;
			ValidateDomain(nome, apelido, dataNascimento);
		}

		public void Update(string nome, string? apelido, DateTime dataNascimento, int clienteId)
		{
			ValidateDomain(nome, apelido, dataNascimento);
			ClienteId = clienteId;
		}

		private void ValidateDomain(string nome, string? apelido, DateTime dataNascimento)
		{
			DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido, nome é obrigatório");
			DomainExceptionValidation.When(nome.Length < 2, "Nome inválido, o nome precisa ter no mínimo 3 caracteres");
			DomainExceptionValidation.When(apelido ? .Length < 3, "Apelido inválido, o apelido precisa ter no mínimo 3 caracteres");
			DomainExceptionValidation.When(dataNascimento > DateTime.Now, "Informe uma data válida");

			Nome = nome;
			Apelido = apelido;
			DataNascimento = dataNascimento;
		}
	}
}
