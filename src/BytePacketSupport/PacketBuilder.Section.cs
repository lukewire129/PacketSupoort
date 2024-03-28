using BytePacketSupport.Extentions;
using System.Collections.Generic;
using System.Linq;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private Dictionary<string, (int, int)> byteKeyPoint=new Dictionary<string, (int, int)> ();

        public PacketBuilder BeginSection(string key)
        {
            if (this.packetData.WrittenCount  == 0)
            {
                byteKeyPoint.Add (key, (0, 0));
                return this;
            }

            byteKeyPoint.Add (key, (this.packetData.WrittenCount - 1, 0));
            return this;
        }

        public PacketBuilder EndSection(string key)
        {
            if (this.packetData.WrittenCount == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key) == false)
                return this;

            byteKeyPoint[key] = (byteKeyPoint[key].Item1, this.packetData.WrittenCount - 1);

            return this;
        }

        public byte[] GetSection(string key) 
        {
            if (this.packetData.WrittenCount == 0)
                return null;

            if (byteKeyPoint.ContainsKey (key) == false)
                return null;

            if (byteKeyPoint[key].Item2 == 0)
                return GetBytes (byteKeyPoint[key].Item1);

            return GetBytes (byteKeyPoint[key].Item1, byteKeyPoint[key].Item2 - byteKeyPoint[key].Item1);
        }

        private byte[] GetBytes(int start)
        {
            return this.packetData.ToArray().Skip(start - 1).ToArray ();
        }

        private byte[] GetBytes(int start, int count)
        {
            return this.packetData.ToArray().Skip (start - 1).Take (count).ToArray ();
        }
    }
}

