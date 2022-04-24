namespace _02.DOM.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.DOM.Interfaces;

    public class HtmlElement : IHtmlElement
    {
        public HtmlElement(ElementType type, params IHtmlElement[] children)
        {
            Type = type;
            this.Children = new List<IHtmlElement>(children.ToList());

            for (int i = 0; i < children.Length; i++)
            {
                this.Children.Add(children[i]);

            }

            Attributes = new Dictionary<string, string>();


        }


        public ElementType Type { get; set; }

        public IHtmlElement Parent { get; set; }

        public List<IHtmlElement> Children { get; }

        public Dictionary<string, string> Attributes { get; }

        public int CompareTo(object obj)
        {
            var other = (IHtmlElement)obj;

            return other.Type - Type;
        }

        public int CompareTo(IHtmlElement other)
        {
            return Type - other.Type;
        }
    }
}
