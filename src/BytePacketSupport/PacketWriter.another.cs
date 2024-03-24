using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public partial class PacketWriter
    {
        public PacketWriter Append(string ascii)
        {
            this.bytes = bytes.Append (ascii);

            return this;
        }

        public PacketWriter Append(string ascii, int offset, int count)
        {
            this.bytes = bytes.Append (ascii, offset, count);

            return this;
        }

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
