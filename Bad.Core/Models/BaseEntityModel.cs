using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bad.Core.Models
{
    public abstract class BaseEntityModel<TType>
    {
        public TType Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
