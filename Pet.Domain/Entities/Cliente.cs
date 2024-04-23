using Pet.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Domain.Entities
{
	public sealed class Cliente : Entity
	{
		public string Nome { get; private set; }
        public string Documento { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public ICollection<Pets> Pets { get; set; }

		public Cliente(string nome, string documento, string email, string telefone, DateTime dataNascimento)
		{
			ValidateDomain(nome, documento, email, telefone, dataNascimento);
		}

		public Cliente(int id, string nome, string documento, string email, string telefone, DateTime dataNascimento)
		{
			DomainExceptionValidation.When(id < 0, "Id inválido");
			Id = id;
			ValidateDomain(nome, documento, email, telefone, dataNascimento);

		}

		public void Update(string nome, string documento, string email, string telefone, DateTime dataNascimento)
		{
			ValidateDomain(nome, documento, email, telefone, dataNascimento);
		}

		private void ValidateDomain(string nome, string documento, string email, string telefone, DateTime dataNascimento)
		{
			DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido, nome é obrigatório");
			DomainExceptionValidation.When(nome.Length < 2, "Nome inválido, o nome precisa ter no mínimo 3 caracteres");

			DomainExceptionValidation.When(string.IsNullOrEmpty(documento), "Documento inválido, documento é obrigatório");
			DomainExceptionValidation.When(documento.Length < 7, "Documento inválido, o documento precisa ter no mínimo 7 caracteres");

			DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Email inválido, email é obrigatório");
			DomainExceptionValidation.When(email.Length <10, "Email inválido, o email precisa ter no mínimo 10 caracteres");

			DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "Telefone inválido, telefone é obrigatório");
			DomainExceptionValidation.When(telefone.Length < 8, "Telefone inválido, o telefone precisa ter no mínimo 8 caracteres");

			DomainExceptionValidation.When(dataNascimento > DateTime.Now, "Data de Nascimento inválida");


			Nome = nome;
			Documento = documento;
			Email = email;
			Telefone = telefone;
			DataNascimento = dataNascimento;
		}
	}
}
