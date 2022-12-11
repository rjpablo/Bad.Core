using Bad.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bad.Events.Entities
{
    public abstract class Event: BaseEntityModel<long>
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [ForeignKey("PrimaryMedia")]
        public long? PrimaryMediaId { get; set; }
        public virtual MultimediaModel PrimaryMedia { get; set; }
        public string CreatedById { get; set; }
    }
}
