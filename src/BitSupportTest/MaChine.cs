using BitSupport.SourceGenerators.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitSupportTest
{
    [BitSupportFlags]
    public enum MaChine
    {
        POWER,
        RIGHT,
        TOP,
        LIGHT,
        TEMP,
        RUN,
        SOUND,
    }
}
