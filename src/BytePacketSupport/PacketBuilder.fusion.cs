using System.Collections.Generic;
using System.Reflection;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        public PacketBuilder @byte(byte data)
        {
            return Append (data);
        }

        public PacketBuilder @bytes(IEnumerable<byte> datas)
        {
            return Append (datas);
        }

        public PacketBuilder @string(string ascii)
        {
            return Append (ascii);
        }

        public PacketBuilder @short(short shortByte)
        {
            return Append (shortByte);
        }

        public PacketBuilder @int(int intByte)
        {
            return Append (intByte);
        }

        public PacketBuilder @long(long longByte)
        {
            return Append (longByte);
        }

        public PacketBuilder @ushort(ushort ushortByte)
        {
            return Append (ushortByte);
        }

        public PacketBuilder @uint(uint uintByte)
        {
            return Append (uintByte);
        }

        public PacketBuilder @ulong (ulong ulongByte)
        {
            return Append (ulongByte);
        }

        public PacketBuilder @class<TSource>(TSource AppenClass) where TSource : class
        {
            return Append (AppenClass);
        }

        public PacketBuilder @packetbuilder(PacketBuilder packetbuilder)
        {
            return AppendBytes (packetbuilder.Build ());
        }
    }
}

