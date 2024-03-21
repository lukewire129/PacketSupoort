// See https://aka.ms/new-console-template for more information

using BytePacketSupport;
using System.Diagnostics;


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

summaryByts = aByte.Append (addBytes);
Console.WriteLine (summaryByts.Display ());
Console.WriteLine (summaryByts.DisplayAscii ());
Console.WriteLine ();

// Example3
Console.WriteLine ("Example3");
byte[] bByte = new byte[2]{ 0x50, 0x51 };
addBytes = 0x52;
Console.WriteLine ("Original Data : {0}", bByte.Display ());
Console.WriteLine ("Add Data 2 : {0}", addBytes.Display ());
summaryByts = bByte.Append (addBytes);

Console.WriteLine (summaryByts.Display ());
Console.WriteLine (summaryByts.DisplayAscii ());
Console.WriteLine ();


// Example4
Console.WriteLine ("Example4");
byte[] cByte = new byte[2] { 0x50, 0x51 };
summaryByts = cByte.Append (new List<byte>
{
    0x52, 0x53
});
Console.WriteLine (summaryByts.Display ());
Console.WriteLine (summaryByts.DisplayAscii ());
Console.WriteLine ();

// Example5
Console.WriteLine ("Example5");
byte[] dByte = new byte[1] { 0x50};
summaryByts = dByte.Append ("hihi");

Console.WriteLine (summaryByts.Display ());
Console.WriteLine (summaryByts.DisplayAscii ());
Console.WriteLine ();

// Example6 TimeTest
Console.WriteLine ("Example6 TimeTest");
Stopwatch sw = Stopwatch.StartNew ();
sw.Start ();
var writerTest = new PacketWriter ();
for (int i = 0; i < 100000; i++)
{
    writerTest.Append (BitConverter.GetBytes (i));
}
sw.Stop ();
//Console.WriteLine (writerTest.GetBytes().Display ());
//Console.WriteLine (writerTest.GetBytes ().DisplayAscii ());
Console.WriteLine ("{0}byte append {1} ms", 100000 * 4, sw.ElapsedMilliseconds);

