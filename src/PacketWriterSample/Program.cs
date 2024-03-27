using BytePacketSupport;

var builder1 = new PacketBuilder ()
               .AppendInt32 (1)
               .AppendUInt32 (2)
               .AppendInt16 (3)
               .AppendUInt16 (4)
               .AppendInt64 (5)
               .AppendUInt64 (6)
               .Build ();

Console.WriteLine(builder1.ToHexString ());

var builder2 = new PacketBuilder ()
               .Appendint (1)
               .Appenduint (2)
               .Appendshort (3)
               .Appendushort (4)
               .Appendlong (5)
               .Appendulong (6)
               .Build ();

Console.WriteLine (builder2.ToHexString ());


var builder3 = new PacketBuilder ()
               .@int (1)
               .@uint (2)
               .@short (3)
               .@ushort (4)
               .@long (5)
               .@ulong (6)
               .Build ();

Console.WriteLine (builder3.ToHexString ());
