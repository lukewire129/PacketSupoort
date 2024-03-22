
using BytePacketSupport;

byte[] bytes = new byte[]{ 0x01, 0x02, 0x03 };

var abc = PacketParse.DeserializeObject<abc> (bytes);
Console.WriteLine ();

class abc
{
    public byte a;
    public byte b;
    public byte c;
}

