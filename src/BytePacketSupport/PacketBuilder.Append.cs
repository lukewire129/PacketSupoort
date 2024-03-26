using BytePacketSupport.Converter;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        public PacketBuilder Append(byte data)
        {
            packetData.Add (data);

            return this;
        }

        public PacketBuilder Append(byte[] datas)
        {
            packetData.AddRange (datas);

            return this;
        }

        public PacketBuilder Append(List<byte> datas)
        {
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Append(string ascii)
        {
            byte[] datas = ByteConverter.GetByte (ascii);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Append(int intByte)
        {
            byte[] datas = ByteConverter.GetByte (intByte, isLittleEnidan);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Append(long longByte)
        {
            byte[] datas = ByteConverter.GetByte (longByte, isLittleEnidan);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Append(short shortByte)
        {
            byte[] datas = ByteConverter.GetByte (shortByte, isLittleEnidan);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Append<TSource>(TSource AppenClass) where TSource : class
        {
            byte[] datas = PacketParse.Serialization (AppenClass);
            packetData.AddRange (datas);
            return this;
        }
    }
}

