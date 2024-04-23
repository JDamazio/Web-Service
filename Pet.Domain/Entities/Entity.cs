using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Domain.Entities
{
	public abstract class Entity
	{
        public int Id { get; protected set; }
        public DateTime Criado { get; protected set; } = DateTime.Now;
        public DateTime? Editado { get; protected set; }
        public DateTime? Deletado { get; protected set; }
        public bool Ativo { get; protected set; } = true;
	}
}
