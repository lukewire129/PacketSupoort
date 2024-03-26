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
            byte[] datas = ByteConverter.GetBytes (ascii);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Append(int intByte)
        {
            byte[] datas = ByteConverter.GetBytes (intByte, isLittleEnidan);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Append(long longByte)
        {
            byte[] datas = ByteConverter.GetBytes (longByte, isLittleEnidan);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Append(short shortByte)
        {
            byte[] datas = ByteConverter.GetBytes (shortByte, isLittleEnidan);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Append<TSource>(TSource AppenClass) where TSource : class
        {
            byte[] datas = PacketParse.Serialize (AppenClass);
            packetData.AddRange (datas);
            return this;
        }
    }
}

