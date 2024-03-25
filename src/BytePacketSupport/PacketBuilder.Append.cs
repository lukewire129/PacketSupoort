using BytePacketSupport.Converter;
using BytePacketSupport.Enums;
using System.Collections.Generic;
using System.Linq;

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
            if (_configuration.DefaultEndian == Endian.LITTLE)
            {
                packetData.AddRange (datas.Reverse());
                return this;
            }
            packetData.AddRange(datas);

            return this;
        }

        public PacketBuilder Append(List<byte> datas)
        {
            if (_configuration.DefaultEndian == Endian.LITTLE)
            {
                datas.Reverse ();
                packetData.AddRange (datas);
                return this;
            }
            packetData.AddRange (datas);

            return this;
        }

        public PacketBuilder Append(string ascii)
        {
            byte[] datas = ByteConverter.GetByte (ascii);
            if (_configuration.DefaultEndian == Endian.LITTLE)
            {
                packetData.AddRange (datas.Reverse ());
                return this;
            }
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Append(int intByte, Endian endian = Endian.BIG)
        {
            byte[] datas = ByteConverter.GetByte (intByte, endian);
            if (_configuration.DefaultEndian == Endian.LITTLE)
            {
                packetData.AddRange (datas.Reverse ());
                return this;
            }
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Append(long longByte, Endian endian = Endian.BIG)
        {
            byte[] datas = ByteConverter.GetByte (longByte, endian);
            if (_configuration.DefaultEndian == Endian.LITTLE)
            {
                packetData.AddRange (datas.Reverse ());
                return this;
            }
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Append(short shortByte, Endian endian = Endian.BIG)
        {
            byte[] datas = ByteConverter.GetByte (shortByte, endian);
            if (_configuration.DefaultEndian == Endian.LITTLE)
            {
                packetData.AddRange (datas.Reverse ());
                return this;
            }
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Append<TSource>(TSource AppenClass) where TSource : class
        {
            byte[] datas = PacketParse.Serialization (AppenClass);
            if (_configuration.DefaultEndian == Endian.LITTLE)
            {
                packetData.AddRange (datas.Reverse ().ToArray ());
                return this;
            }
            packetData.AddRange (datas);
            return this;
        }
    }
}

