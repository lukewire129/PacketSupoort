using System;

namespace PacketSupport.Core.Attibutes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ByteSizeAttribute : Attribute
    {
        public int Size { get; set; }

        public ByteSizeAttribute(int size)
        {
            Size = size;
        }
    }
}
