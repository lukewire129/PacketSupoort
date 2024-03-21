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
            this.bytes = bytes.AppendByte (packet);
            return this;
        }

        public PacketWriter Append(byte[] packet)
        {
            this.bytes = bytes.AppendBytes (packet);
            return this;
        }
        public PacketWriter Append(string ascii)
        {
            byte[] asciibyte = Encoding.ASCII.GetBytes (ascii);
            this.bytes = bytes.AppendBytes (asciibyte);

            return this;
        }
        public PacketWriter Append(byte[] packet, int offset, int count)
        {
            this.bytes = bytes.AppendBytes (packet, offset, count);
            return this;
        }

        public PacketWriter Append(List<byte> packet)
        {
            this.bytes = bytes.AppendBytes (packet.ToArray());
            return this;
        }

        public PacketWriter Append(List<byte> packet, int offset, int count)
        {
            this.bytes = bytes.AppendBytes (packet.ToArray (), offset, count);
            return this;
        }

        public byte[] GetBytes() => this.bytes;
    }
}
