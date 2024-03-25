using BytePacketSupport.Converter;
using BytePacketSupport.Enums;
using Mythosia.Integrity.Checksum;
using Mythosia.Integrity.CRC;
using System.Collections.Generic;
using System.Linq;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        public PacketBuilder ErrorDetection(Checksum8Type checkSum8)
        {
            byte[] errorcheck = new Checksum8 (checkSum8).Compute (this.packetData.ToArray ()).ToArray();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder ErrorDetection(Checksum8Type checkSum8, int start)
        {
            byte[] errorcheck = new Checksum8 (checkSum8).Compute (this.packetData.Skip (start - 1).ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder ErrorDetection(Checksum8Type checkSum8, int start, int count)
        {
            byte[] errorcheck = new Checksum8 (checkSum8).Compute (this.packetData.Skip (start - 1).Take (count).ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder ErrorDetection(CRC8Type Crc8Type)
        {
            byte[] errorcheck = new CRC8 (Crc8Type).Compute (this.packetData.ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder ErrorDetection(CRC8Type Crc8Type, int start)
        {
            byte[] errorcheck = new CRC8 (Crc8Type).Compute (this.packetData.Skip (start - 1).ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);
            
            return this;
        }
        public PacketBuilder ErrorDetection(CRC8Type Crc8Type, int start, int count)
        {
            byte[] errorcheck = new CRC8 (Crc8Type).Compute (this.packetData.Skip (start - 1).Take (count).ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder ErrorDetection(CRC16Type Crc16Type)
        {
            byte[] errorcheck = new CRC16 (Crc16Type).Compute (this.packetData.ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder ErrorDetection(CRC16Type Crc16Type, int start)
        {
            byte[] errorcheck = new CRC16 (Crc16Type).Compute (this.packetData.Skip (start - 1).ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder ErrorDetection(CRC16Type Crc16Type, int start, int count)
        {
            byte[] errorcheck = new CRC16 (Crc16Type).Compute (this.packetData.Skip (start - 1).Take (count).ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder ErrorDetection(CRC32Type Crc32Type)
        {
            byte[] errorcheck = new CRC32 (Crc32Type).Compute (this.packetData.ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder ErrorDetection(CRC32Type Crc32Type, int start)
        {
            byte[] errorcheck = new CRC32 (Crc32Type).Compute (this.packetData.Skip (start - 1).ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder ErrorDetection(CRC32Type Crc32Type, int start, int count)
        {
            byte[] errorcheck = new CRC32 (Crc32Type).Compute (this.packetData.Skip (start - 1).Take (count).ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }
    }
}

