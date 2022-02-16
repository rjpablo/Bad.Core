using Bad.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bad.Core.Models
{
    public class MultimediaModel: BaseEntityModel<long>
    {
        public string Url { get; set; }
        public MultimediaTypeEnum Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
