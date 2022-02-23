using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bad.Core.Models
{
    public class IndexedEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string PhotoUrl { get; set; }
    }
}
