using Mythosia.Integrity.Checksum;
using Mythosia.Integrity.CRC;
using System.Collections.Generic;
using System.Linq;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private Dictionary<string, (int, int)> byteKeyPoint=new Dictionary<string, (int, int)> ();

        public PacketBuilder PointSaveStart(string key)
        {
            if (this.packetData.Count () == 0)
            {
                byteKeyPoint.Add (key, (0, 0));
                return this;
            }

            byteKeyPoint.Add (key, (this.packetData.Count () - 1, 0));
            return this;
        }

        public PacketBuilder PointSaveEnd(string key)
        {
            if (this.packetData.Count () == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key))
                return this;

            byteKeyPoint[key] = (byteKeyPoint[key].Item1, this.packetData.Count () - 1);

            return this;
        }

        public PacketBuilder Checksum(string key, Checksum8Type checksum8Type)
        {
            if (this.packetData.Count () == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key))
                return this;

            this.ErrorDetection (checksum8Type, byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
            return this;
        }

        public PacketBuilder Checksum(string key, CRC8Type crc8Type)
        {
            if (this.packetData.Count () == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key))
                return this;

            this.ErrorDetection (crc8Type, byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
            return this;
        }
        public PacketBuilder Checksum(string key, CRC16Type crc16Type)
        {
            if (this.packetData.Count () == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key))
                return this;

            this.ErrorDetection (crc16Type, byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
            return this;
        }

        public PacketBuilder Checksum(string key, CRC32Type crc32Type)
        {
            if (this.packetData.Count () == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key))
                return this;

            this.ErrorDetection (crc32Type, byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
            return this;
        }

        public byte[] GetSavePoint(string key) 
        {
            if (this.packetData.Count () == 0)
                return null;

            if (byteKeyPoint.ContainsKey (key))
                return null;

            if (byteKeyPoint[key].Item2 == 0)
                return GetBytes (byteKeyPoint[key].Item1);

            return GetBytes (byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
        }

        private byte[] GetBytes(int start)
        {
            return this.packetData.Skip (start - 1).ToArray ();
        }

        private byte[] GetBytes(int start, int count)
        {
            return this.packetData.Skip (start - 1).Take (count).ToArray ();
        }
    }
}

