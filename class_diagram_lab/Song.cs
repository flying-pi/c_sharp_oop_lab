using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace class_diagram_lab
{
    public class Song : LiteraryWork
    {
        private string music="";

        public Song() : base()
        {
        }
        public Song(string content="", string name="", string author="", string music="") :base(content, name,author)
        {
            this.music = music;
        }

        public String Music
        {
            get
            {
                return music;
            }

            set
            {
                music = value;
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()}; Music :: {Music}";
        }
    }
}