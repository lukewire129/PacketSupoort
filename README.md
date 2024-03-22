### BytePacketSupport

## use
1. PacketWriter class
2. Extentions
3. bytearray - class (Serialization, Deserialization)
   
## output print
1. Display() => only byte
2. DisplayAscii() => AsciiCode Byte

## 0. output print
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
```

## 2. Extentions
- byte + byte array
``` csharp
byte[] summaryByts;
byte testByte = 0x51;

summaryByts = testByte.Append(new byte[]
                              {
                                0x52,
                                0x53
                              });
```
 
- byte + byte array
``` csharp
byte[] summaryByts;
byte testByte = 0x51;

summaryByts = testByte.Append(new List<byte>
                                 {
                                   0x52,
                                   0x53
                                 });
/* and
summaryByts = testByte.Append(new byte[]()
                                 {
                                   0x52,
                                   0x53
                                 });
*/
```

- byte array + byte array
``` csharp
byte[] summaryByts;
List<byte> testByte = new List<byte>(){0x51, 0x52, 0x53};

summaryByts = testByte.Append(new List<byte>
                                 {
                                   0x54,
                                   0x55
                                 });
```

## 3. bytearray - class (Serialization, Deserialization)
- For an array or string, you must size it.
- The size should be set via attribute (ByteSize), and in the case of 'List' Type, it can be handled by adjusting the Capacity value.
  If there is no capacity or attribute value, an empty value is returned.
```csharp
public class Test2Packet
{
    public int Value;
    [ByteSize (3)]
    public string Value1;
    [ByteSize (3)]
    public string Value2;
    [ByteSize(4)]
    public byte[] abc;            
    public byte[] efg = new byte[5];
    public List<byte> qqq= new List<byte>(5);
    public List<byte> qqq1= new List<byte>();
}

[Fact]
public void TestDeserializeObject()
{
    var test = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x61, 0x62,0x63,0x41,0x42,0x43, 0x01, 0x00, 0x00, 0x00, 0x61, 0x62, 0x63, 0x41, 0x42, 0x43, 0x01, 0x00, 0x00, 0x00, 0x61, 0x62, 0x63, 0x41, 0x42, 0x43 };
    var aaa = PacketParse.DeserializeObject<Test2Packet> (test);

    var abc  = PacketParse.Serialization (aaa);
}
```
