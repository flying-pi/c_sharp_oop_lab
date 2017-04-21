using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace class_diagram_lab
{
    [Flags]
    public enum EGenre
    {
        eUnknown = 0,
        eAntique = 1,
        eKnightly = 2,
        eAllegorical = 4,
        ePsychological = 8
    }
}