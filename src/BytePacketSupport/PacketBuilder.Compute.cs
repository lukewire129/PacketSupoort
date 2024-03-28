using BytePacketSupport.Extentions;
using Mythosia.Integrity;
using Mythosia.Integrity.Checksum;
using Mythosia.Integrity.CRC;
using System.Drawing;
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

        public PacketBuilder Compute(CRC16Type type)
        {
            Compute (new CRC16 (type), this.packetData.ToArray ());
            return this;
        }

        public PacketBuilder Compute(CRC16Type type, int start)
        {
            Compute(new CRC16 (type), GetBytes (start));
            return this;
        }

        public PacketBuilder Compute(CRC16Type type, int start, int count)
        {
            Compute (new CRC16 (type), GetBytes (start, count));

            return this;
        }

        public PacketBuilder Compute(CRC32Type type)
        {
            Compute (new CRC32 (type), this.packetData.ToArray ());
            return this;
        }

        public PacketBuilder Compute(CRC32Type type, int start)
        {
            Compute (new CRC32 (type), GetBytes (start));
            return this;
        }

        public PacketBuilder Compute(CRC32Type type, int start, int count)
        {
            Compute (new CRC32 (type), GetBytes (start, count));
            return this;
        }


        public PacketBuilder Compute(string key, Checksum8Type type)
        {
            if (this.packetData.WrittenCount == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key))
                return this;

            this.Compute (type, byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
            return this;
        }

        public PacketBuilder Compute(string key, CRC8Type type)
        {
            if (this.packetData.WrittenCount == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key))
                return this;

            this.Compute (type, byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
            return this;
        }
        public PacketBuilder Compute(string key, CRC16Type type)
        {
            if (this.packetData.WrittenCount == 0)
                return this;
            if (byteKeyPoint.ContainsKey (key))
                return this;

            this.Compute (type, byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
            return this;
        }

        public PacketBuilder Compute(string key, CRC32Type type)
        {
            if (this.packetData.WrittenCount == 0)
                return this;
            if (byteKeyPoint.ContainsKey (key))
                return this;

            this.Compute (type, byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
            return this;
        }
    }
}

