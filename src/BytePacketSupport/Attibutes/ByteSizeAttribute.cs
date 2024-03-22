using System;

namespace BytePacketSupport.Attibutes
{

    public class ByteSizeAttribute : Attribute
    {
        public int Size { get; }

        public ByteSizeAttribute(int size)
        {
            Size = size;
        }
    }
}
