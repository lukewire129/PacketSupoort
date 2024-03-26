﻿using BytePacketSupport.Converter;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        public PacketBuilder @byte(byte data)
        {
            packetData.Add (data);

            return this;
        }

        public PacketBuilder @bytes(byte[] datas)
        {
            packetData.AddRange (datas);

            return this;
        }

        public PacketBuilder @bytes(List<byte> datas)
        {
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @string(string ascii)
        {
            byte[] datas = ByteConverter.GetBytes (ascii);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @int(int intByte)
        {
            byte[] datas = ByteConverter.GetBytes (intByte, isMustReverseUnit);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @long(long longByte)
        {
            byte[] datas = ByteConverter.GetBytes (longByte, isMustReverseUnit);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @short(short shortByte)
        {
            byte[] datas = ByteConverter.GetBytes (shortByte, isMustReverseUnit);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @uint(uint uintByte)
        {
            byte[] datas = ByteConverter.GetBytes (uintByte, isMustReverseUnit);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @ulong (ulong ulongByte)
        {
            byte[] datas = ByteConverter.GetBytes (ulongByte, isMustReverseUnit);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @ushort (ushort ushortByte)
        {
            byte[] datas = ByteConverter.GetBytes (ushortByte, isMustReverseUnit);
            packetData.AddRange (datas);
            return this;
        }


        public PacketBuilder @class<TSource>(TSource AppenClass) where TSource : class
        {
            byte[] datas = PacketParse.Serialize (AppenClass);
            packetData.AddRange (datas);
            return this;
        }
    }
}

