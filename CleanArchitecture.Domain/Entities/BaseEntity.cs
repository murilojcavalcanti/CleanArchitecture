using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        //Esse tipo é uma estrutura que representa uma data e hora, além do deslocamento para UTC.
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
    }
}
