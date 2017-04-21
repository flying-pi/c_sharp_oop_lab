using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace class_diagram_lab
{
    public class LiteraryWork : Product
    {

        private long symbolsCount = 0;
        private string author = "";
        private string content = "";



        public LiteraryWork(string content="", string name="", string author="")
        {
            this.Author = author;
            this.Content = content;
            this.Name = name;
        }

        public long SymbolCount
        {
            get
            {
                return symbolsCount;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                symbolsCount = value.Length;
                content = value;
            }
        }

        override public string ToString()
        {
            return $"name :: {Name}\t author :: {author}\t content :: {(content.Length > 25 ? content.Substring(0, 25) + "...." : content)}";
        }
    }
}