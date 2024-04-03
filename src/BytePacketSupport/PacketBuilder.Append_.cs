using System.Collections.Generic;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        public PacketBuilder AppendByte(byte data)
        {
            return Append (data);
        }

        public PacketBuilder AppendBytes(IEnumerable<byte> datas)
        {
            return Append (datas);
        }

        public PacketBuilder AppendString(string ascii)
        {
            return Append (ascii);
        }

        public PacketBuilder AppendPacketBuilder(PacketBuilder builder)
        {
            return AppendBytes (builder.Build ());
        }

        public PacketBuilder AppendClass<TSource>(TSource AppendClass) where TSource : class
        {
            return Append (AppendClass);
        }
    }
}

