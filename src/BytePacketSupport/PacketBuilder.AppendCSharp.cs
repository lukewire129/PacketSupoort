using BytePacketSupport.Converter;
using System.Data;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        public PacketBuilder Appendshort(short shortByte)
        {
            return Append (shortByte);
        }
        public PacketBuilder Appendint(int intByte)
        {
            return Append (intByte);
        }

        public PacketBuilder Appendlong(long longByte)
        {
            return Append (longByte);
        }

        public PacketBuilder Appendushort(ushort ushortByte)
        {
            return Append (ushortByte);
        }

        public PacketBuilder Appenduint(uint uintByte)
        {
            return Append (uintByte);
        }

        public PacketBuilder Appendulong (ulong ulongByte)
        {
            return Append (ulongByte);
        }
    }
}

