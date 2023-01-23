using System;
using System.Collections.Generic;
using System.Text;

namespace Bad.Core.Models
{
    public class ChoiceItemModel<TValue, TType>
    {
        /// <summary>
        /// The text that will be displayed in the list of suggestions
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// The value that will be returned when this choice is selected
        /// </summary>
        public TValue Value { get; set; }

        public string IconUrl { get; set; }
        /// <summary>
        /// The type of this choice item
        /// </summary>
        public TType Type { get; set; }

        public ChoiceItemModel() { }

        public ChoiceItemModel(string text, TValue value, string iconUrl, TType type)
        {
            Text = text;
            Value = value;
            IconUrl = iconUrl;
            Type = type;
        }
    }
}
