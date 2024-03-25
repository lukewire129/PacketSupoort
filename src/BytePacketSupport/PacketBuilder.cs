using BytePacketSupport.Converter;
using BytePacketSupport.Enums;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private List<byte> packetData = new List<byte> ();

        public PacketBuilder Append(byte data)
        {
            packetData.Add (data);

            return this;
        }

        public PacketBuilder Append(byte[] data)
        {
            packetData.AddRange(data);

            return this;
        }

        public PacketBuilder Append(List<byte> data)
        {
            packetData.AddRange (data);

            return this;
        }

        public PacketBuilder Append(string ascii)
        {
            packetData.AddRange (ByteConverter.GetByte (ascii));
            return this;
        }

        public PacketBuilder Append(int intByte, Endian endian = Endian.BIG)
        {
            packetData.AddRange (ByteConverter.GetByte (intByte, endian));
            return this;
        }

        public PacketBuilder Append(long longByte, Endian endian = Endian.BIG)
        {
            packetData.AddRange (ByteConverter.GetByte (longByte, endian));
            return this;
        }

        public PacketBuilder Append(short shortByte, Endian endian = Endian.BIG)
        {
            packetData.AddRange (ByteConverter.GetByte (shortByte, endian));
            return this;
        }

        public PacketBuilder Append<TSource>(TSource AppenClass) where TSource : class
        {
            packetData.AddRange (PacketParse.Serialization (AppenClass));
            return this;
        }

        public byte[] Build()
        {
            return this.packetData.ToArray ();
        }
    }
}
