using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public partial class PacketWriter
    {
        public PacketWriter Append(short shortByte, Endian endian = Endian.BIG)
        {
            this.bytes = bytes.Append (shortByte, endian);

            return this;
        }

        public PacketWriter Append(short shortByte, int offset, int count, Endian endian = Endian.BIG) 
        {
            this.bytes = bytes.Append (shortByte, offset, count, endian);

            return this;
        }
    }
}
