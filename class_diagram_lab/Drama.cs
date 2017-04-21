using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace class_diagram_lab
{
    public class Drama : LiteraryWork
    {
        public Drama(): base()
        {

        }


        public Drama(string content = "", string name = "", string author="") : base(content, name, author)
        {

        }

        private int sceneCount;

        public int SceneCount
        {
            get
            {
                return sceneCount;
            }

            set
            {
                sceneCount = value;
            }
        }

        override public string ToString()
        {
            return $"{base.ToString()} SceneCount = {sceneCount}";
        }
    }

}