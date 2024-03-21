### BytePacketSupport

## use
1. PacketWriter class
2. Extentions

## output print
1. Display() => only byte
2. DisplayAscii() => AsciiCode Byte


## 1. PacketWriter 
- Append Byte
```csharp
var writer = new PacketWriter ()
               .Append (0x40)
               .Append (0x41)
               .Append (0x42)
               .Append (0x43)
               .Append (0x44)
               .Append (0x45);

var bytes = writer.GetBytes();

Console.WriteLine (bytes.Display ());
Console.WriteLine (bytes.DisplayAscii ());

// output

// 404142434445
// @ABCDE
```
- Append Byte Array
```csharp
var writer = new PacketWriter ();
writer.Append(new List<byte>()
{
0x40,
0x41,
0x42,
0x43,
0x44,
0x45,
});
/* and
writer.Append(new byte[]
{
0x40,
0x41,
0x42,
0x43,
0x44,
0x45,
});
*/
var bytes = writer.GetBytes();

Console.WriteLine (bytes.Display ());
Console.WriteLine (bytes.DisplayAscii ());

// output

// 404142434445
// @ABCDE
```

## 2. Extentions
- byte + byte array
``` csharp
byte[] summaryByts;
byte testByte = 0x51;

summaryByts = testByte.AppendBytes(new byte[]
                              {
                                0x52,
                                0x53
                              });
Console.WriteLine (summaryByts.Display ());
Console.WriteLine (summaryByts.DisplayAscii ());

// output

// 515253
// QRS
```
 
- byte + byte array
``` csharp
byte[] summaryByts;
byte testByte = 0x51;

summaryByts = testByte.AppendBytes(new List<byte>
                                 {
                                   0x52,
                                   0x53
                                 });
/* and
summaryByts = testByte.AppendBytes(new byte[]()
                                 {
                                   0x52,
                                   0x53
                                 });
*/
Console.WriteLine (summaryByts.Display ());
Console.WriteLine (summaryByts.DisplayAscii ());

// output

// 515253
// QRS
```

- byte array + byte array
``` csharp
byte[] summaryByts;
List<byte> testByte = new List<byte>(){0x51, 0x52, 0x53};

summaryByts = testByte.AppendBytes(new List<byte>
                                 {
                                   0x54,
                                   0x55
                                 });
Console.WriteLine (summaryByts.Display ());
Console.WriteLine (summaryByts.DisplayAscii ());

// output

// 5152535455
// QRSTU
```

## TimeTest 400,000 Byte Append Test
``` csharp
Console.WriteLine ("Example6 TimeTest");
Stopwatch sw = Stopwatch.StartNew ();
sw.Start ();
var writerTest = new PacketWriter ();
for (int i = 0; i < 100000; i++)
{
    writerTest.Append (BitConverter.GetBytes (i));
}
sw.Stop ();

Console.WriteLine ("{0}byte append {1} ms", 100000 * 4, sw.ElapsedMilliseconds);

/*output
Example6 TimeTest
400000byte append 2783 ms
*/
```

    
