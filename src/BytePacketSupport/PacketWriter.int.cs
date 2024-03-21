using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public partial class PacketWriter
    {
        public PacketWriter Append(int intByte, Endian endian = Endian.BIG)
        {
            this.bytes = bytes.Append (intByte, endian);

            return this;
        }

        public PacketWriter Append(int intByte, int offset, int count, Endian endian = Endian.BIG)
        {
            this.bytes = bytes.Append (intByte, offset, count, endian);

            return this;
        }
    }
}
