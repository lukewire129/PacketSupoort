using BytePacketSupport.Enums;
using System;

namespace BytePacketSupport.Attibutes
{
    [AttributeUsage (AttributeTargets.Field, AllowMultiple = false)]
    public class EndianAttribute : Attribute
    {
        public Endian _endian { get; set; } = Endian.LITTLE;

        public EndianAttribute(Endian endian)
        {
            _endian = endian;
        }
    }
}
