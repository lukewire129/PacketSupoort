using Mythosia.Integrity.Checksum;
using Mythosia.Integrity.CRC;
using System.Linq;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        public PacketBuilder Compute(Checksum8Type checkSum8)
        {
            byte[] errorcheck = new Checksum8 (checkSum8).Compute (this.packetData.ToArray ()).ToArray();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder Compute(Checksum8Type checkSum8, int start)
        {
            byte[] errorcheck = new Checksum8 (checkSum8).Compute (GetBytes (start)).ToArray ();
            this.packetData.AddRange (errorcheck);
            return this;
        }

        public PacketBuilder Compute(Checksum8Type checkSum8, int start, int count)
        {
            byte[] errorcheck = new Checksum8 (checkSum8).Compute (GetBytes (start, count)).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder Compute(CRC8Type Crc8Type)
        {
            byte[] errorcheck = new CRC8 (Crc8Type).Compute (this.packetData.ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder Compute(CRC8Type Crc8Type, int start)
        {
            byte[] errorcheck = new CRC8 (Crc8Type).Compute (GetBytes (start)).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }
        public PacketBuilder Compute(CRC8Type Crc8Type, int start, int count)
        {
            byte[] errorcheck = new CRC8 (Crc8Type).Compute (GetBytes (start, count)).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder Compute(CRC16Type Crc16Type)
        {
            byte[] errorcheck = new CRC16 (Crc16Type).Compute (this.packetData.ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder Compute(CRC16Type Crc16Type, int start)
        {
            byte[] errorcheck = new CRC16 (Crc16Type).Compute (GetBytes (start)).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder Compute(CRC16Type Crc16Type, int start, int count)
        {
            byte[] errorcheck = new CRC16 (Crc16Type).Compute (GetBytes(start, count)).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder Compute(CRC32Type Crc32Type)
        {
            byte[] errorcheck = new CRC32 (Crc32Type).Compute (this.packetData.ToArray ()).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder Compute(CRC32Type Crc32Type, int start)
        {
            byte[] errorcheck = new CRC32 (Crc32Type).Compute (GetBytes(start)).ToArray ();
            this.packetData.AddRange (errorcheck);

            return this;
        }

        public PacketBuilder Compute(CRC32Type Crc32Type, int start, int count)
        {
            byte[] errorcheck = new CRC32 (Crc32Type).Compute (GetBytes (start, count)).ToArray ();
            this.packetData.AddRange (errorcheck);
            return this;
        }


        public PacketBuilder Compute(string key, Checksum8Type checksum8Type)
        {
            if (this.packetData.Count () == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key))
                return this;

            this.Compute (checksum8Type, byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
            return this;
        }

        public PacketBuilder Compute(string key, CRC8Type crc8Type)
        {
            if (this.packetData.Count () == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key))
                return this;

            this.Compute (crc8Type, byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
            return this;
        }
        public PacketBuilder Compute(string key, CRC16Type crc16Type)
        {
            if (this.packetData.Count () == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key))
                return this;

            this.Compute (crc16Type, byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
            return this;
        }

        public PacketBuilder Compute(string key, CRC32Type crc32Type)
        {
            if (this.packetData.Count () == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key))
                return this;

            this.Compute (crc32Type, byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
            return this;
        }
    }
}

