using PacketSupport.Core.Enums;
using System;

namespace PacketSupport.Core.Attibutes
{
    [AttributeUsage (AttributeTargets.Class, AllowMultiple = false)]
    public class EndianAttribute : Attribute
    {
        public Endian _endian { get; set; } = Endian.LITTLE;

        public EndianAttribute(Endian endian)
        {
            _endian = endian;
        }
    }
}
