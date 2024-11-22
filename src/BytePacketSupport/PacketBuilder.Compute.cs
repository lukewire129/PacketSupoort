using BytePacketSupport.Extentions;
using BytePacketSupport.Integrity;
using BytePacketSupport.Integrity.Checksum;
using BytePacketSupport.Integrity.CRC;
using System;
using System.Buffers;
using System.Linq;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private void Compute(ErrorDetection detection, byte[] data)
        {
            byte[] errorcheck = detection.Compute (data).ToArray();
            this.AppendBytes (errorcheck);
        }
        public PacketBuilder Compute(Checksum8Type type)
        {
            Compute (new Checksum8 (type), this.packetData.ToArray ());
            return this;
        }

        public PacketBuilder Compute(Checksum8Type type, int start)
        {
            Compute (new Checksum8 (type), GetBytes (start));
            return this;
        }

        public PacketBuilder Compute(Checksum8Type type, int start, int count)
        {
            Compute (new Checksum8 (type), GetBytes (start,count));
            return this;
        }

        public PacketBuilder Compute(CRC8Type type)
        {
            Compute (new CRC8 (type), this.packetData.ToArray ());
            return this;
        }

        public PacketBuilder Compute(CRC8Type type, int start)
        {
            Compute (new CRC8 (type), GetBytes (start));
            return this;
        }
        public PacketBuilder Compute(CRC8Type type, int start, int count)
        {
            Compute (new CRC8 (type), GetBytes (start, count));
            return this;
        }
        private bool GetendianType()
        {
            if(BitConverter.IsLittleEndian == true)
            {
                if (endianType == PacketSupport.Core.Enums.Endian.BIG || endianType == PacketSupport.Core.Enums.Endian.LITTLEBYTESWAP)
                    return true;
            }
            else
            {
                if (endianType == PacketSupport.Core.Enums.Endian.LITTLE || endianType == PacketSupport.Core.Enums.Endian.BIGBYTESWAP)
                    return true;
            }
            return false;
        }

        public PacketBuilder Compute(CRC16Type type)
        {
            bool isLittleEndia = GetendianType();
            Compute (new CRC16 (type, isLittleEndia), this.packetData.ToArray ());
            return this;
        }

        public PacketBuilder Compute(CRC16Type type, int start)
        {
            bool isLittleEndia = GetendianType ();

            Compute (new CRC16 (type, isLittleEndia), GetBytes (start));
            return this;
        }

        public PacketBuilder Compute(CRC16Type type, int start, int count)
        {
            bool isLittleEndia = GetendianType ();

            Compute (new CRC16 (type, isLittleEndia), GetBytes (start, count));

            return this;
        }

        public PacketBuilder Compute(CRC32Type type)
        {
            bool isLittleEndia = GetendianType ();

            Compute (new CRC32 (type, isLittleEndia), this.packetData.ToArray ());
            return this;
        }

        public PacketBuilder Compute(CRC32Type type, int start)
        {
            bool isLittleEndia = GetendianType ();

            Compute (new CRC32 (type, isLittleEndia), GetBytes (start));
            return this;
        }

        public PacketBuilder Compute(CRC32Type type, int start, int count)
        {
            bool isLittleEndia = GetendianType ();

            Compute (new CRC32 (type, isLittleEndia), GetBytes (start, count));
            return this;
        }


        public PacketBuilder Compute(string key, Checksum8Type type)
        {
            if (this.packetData.WrittenCount == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key) == false)
                return this;

            this.Compute (type, byteKeyPoint[key].Item1, byteKeyPoint[key].count);
            return this;
        }

        public PacketBuilder Compute(string key, CRC8Type type)
        {
            if (this.packetData.WrittenCount == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key) == false)
                return this;

            this.Compute (type, byteKeyPoint[key].start, byteKeyPoint[key].count);
            return this;
        }
        public PacketBuilder Compute(string key, CRC16Type type)
        {
            if (this.packetData.WrittenCount == 0)
                return this;
            if (byteKeyPoint.ContainsKey (key) == false)
                return this;

            this.Compute (type, byteKeyPoint[key].start, byteKeyPoint[key].count);
            return this;
        }

        public PacketBuilder Compute(string key, CRC32Type type)
        {
            if (this.packetData.WrittenCount == 0)
                return this;
            if (byteKeyPoint.ContainsKey (key) == false)
                return this;

            this.Compute (type, byteKeyPoint[key].Item1, byteKeyPoint[key].count);
            return this;
        }
    }
}

