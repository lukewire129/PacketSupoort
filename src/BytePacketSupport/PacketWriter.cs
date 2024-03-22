using System.Collections.Generic;
using System.Linq;

namespace BytePacketSupport
{
    public partial class PacketWriter
    {
        byte[] bytes;
        public PacketWriter()
        {
            bytes = new byte[0];
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
        public PacketWriter Reverse()
        {
            this.bytes = this.bytes.Reverse ().ToArray ();

            return this;
        }

        public long Length() => this.bytes.LongLength;
        public byte[] GetBytes() => this.bytes;

        public void Clear()
        {
            this.bytes = new byte[0];
        }
    }
}
