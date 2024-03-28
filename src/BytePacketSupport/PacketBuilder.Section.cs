using System.Collections.Generic;
using System.Linq;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private Dictionary<string, (int start, int count)> byteKeyPoint=new Dictionary<string, (int, int)> ();

        public PacketBuilder BeginSection(string key)
        {
            byteKeyPoint.Add (key, (this.packetData.Count (), 0));
            return this;
        }

        public PacketBuilder EndSection(string key)
        {
            if (this.packetData.Count () == 0)
                return this;

            if (byteKeyPoint.ContainsKey (key) == false)
                return this;

            byteKeyPoint[key] = (byteKeyPoint[key].start, this.packetData.Count () - byteKeyPoint[key].start);

            return this;
        }

        public byte[] GetSection(string key) 
        {
            if (this.packetData.Count () == 0)
                return null;

            if (byteKeyPoint.ContainsKey (key) == false)
                return null;

            if (byteKeyPoint[key].Item2 == 0)
                return GetBytes (byteKeyPoint[key].start);

            return GetBytes (byteKeyPoint[key].start, byteKeyPoint[key].count);
        }

        private byte[] GetBytes(int start)
        {
            return this.packetData.Skip (start).ToArray ();
        }

        private byte[] GetBytes(int start, int count)
        {
            return this.packetData.Skip (start).Take (count).ToArray ();
        }
    }
}

