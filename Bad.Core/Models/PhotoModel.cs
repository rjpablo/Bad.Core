using Bad.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bad.Core.Models
{
    public class PhotoModel
    {
        public new MultimediaTypeEnum Type { get; } = MultimediaTypeEnum.Photo;
    }
}
