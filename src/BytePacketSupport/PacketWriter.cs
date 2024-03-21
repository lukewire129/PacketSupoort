using System.Collections.Generic;
using System.Text;

namespace BytePacketSupport
{
    public class PacketWriter
    {
        byte[] bytes;
        public PacketWriter()
        {
            bytes = new byte[0];
        }

        public PacketWriter(int length)
        {
            bytes = new byte[length];
        }

        public PacketWriter Append(byte packet)
        {
            this.bytes = bytes.Append (packet);
            return this;
        }

        public PacketWriter Append(byte[] packet)
        {
            this.bytes = bytes.Append (packet);
            return this;
        }
        public PacketWriter Append(string ascii)
        {
            this.bytes = bytes.Append (ascii);

            return this;
        }

        public PacketWriter Append(byte[] packet, int offset, int count)
        {
            this.bytes = bytes.Append (packet, offset, count);
            return this;
        }

        public PacketWriter Append(List<byte> packet)
        {
            this.bytes = bytes.Append (packet.ToArray());
            return this;
        }

        public PacketWriter Append(List<byte> packet, int offset, int count)
        {
            this.bytes = bytes.Append (packet.ToArray (), offset, count);
            return this;
        }

        public byte[] GetBytes() => this.bytes;
    }
}
