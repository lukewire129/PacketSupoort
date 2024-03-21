// See https://aka.ms/new-console-template for more information

using BytePacketSupport;


// Example1
Console.WriteLine ("Example1");
var writer = new PacketWriter ()
                    .Append (0x40)
                    .Append (0x41)
                    .Append (0x42)
                    .Append (0x43)
                    .Append (0x44)
                    .Append (0x45);

var bytes = writer.GetBytes ();

Console.WriteLine (bytes.Display ());
Console.WriteLine (bytes.DisplayAscii ());
Console.WriteLine ();

byte[] summaryByts;
Console.WriteLine ("Example2");

// Example2
byte aByte = 0x50;
byte addBytes = 0x51;
Console.WriteLine ("Original Data : {0}", aByte.Display ());
Console.WriteLine ("Add Data 2 : {0}", addBytes.Display ());

summaryByts = aByte.AppendByte (addBytes);
Console.WriteLine (summaryByts.Display ());
Console.WriteLine (summaryByts.DisplayAscii ());
Console.WriteLine ();

// Example3
Console.WriteLine ("Example3");
byte[] bByte = new byte[2]{ 0x50, 0x51 };
addBytes = 0x52;
Console.WriteLine ("Original Data : {0}", bByte.Display ());
Console.WriteLine ("Add Data 2 : {0}", addBytes.Display ());
summaryByts = bByte.AppendByte (addBytes);

Console.WriteLine (summaryByts.Display ());
Console.WriteLine (summaryByts.DisplayAscii ());
Console.WriteLine ();


// Example4
Console.WriteLine ("Example4");
byte[] cByte = new byte[2] { 0x50, 0x51 };
summaryByts = cByte.AppendBytes (new List<byte>
{
    0x52, 0x53
});
Console.WriteLine (summaryByts.Display ());
Console.WriteLine (summaryByts.DisplayAscii ());


// Example5
Console.WriteLine ("Example5");
byte[] dByte = new byte[1] { 0x50};
summaryByts = dByte.AppendASCII ("hihi");

Console.WriteLine (summaryByts.Display ());
Console.WriteLine (summaryByts.DisplayAscii ());
