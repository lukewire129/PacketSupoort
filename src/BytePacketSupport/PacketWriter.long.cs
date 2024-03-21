using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public partial class PacketWriter
    {
        public PacketWriter Append(long longByte, Endian endian = Endian.BIG)
        {
            this.bytes = bytes.Append (longByte, endian);

            return this;
        }

        public PacketWriter Append(long longByte, int offset, int count, Endian endian = Endian.BIG) 
        {
            this.bytes = bytes.Append (longByte, offset, count, endian);

            return this;
        }
    }
}
