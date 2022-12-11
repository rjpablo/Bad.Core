using Bad.Core.Models;
using DataAnnotationsExtensions;
using System;
using System.ComponentModel;

namespace Bad.Events.Entities
{
    public abstract class EventSchedule : BaseEntityModel<long>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [DisplayName("No. of Slots")]
        [Min(1)]
        public int NumberOfSlots { get; set; }
    }
}
