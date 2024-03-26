### BytePacketSupport
<img src = "https://github.com/lukewire129/BytePacketSupport/assets/54387261/1a9028b0-ae1f-4f5f-82f7-18ecde0ca360" width="100" height="100">

"Icon made by Freepik from www.flaticon.com"
([Link](https://www.flaticon.com/free-icon/brick-wall_1887007?term=brick&related_id=1887007))

#### PacketSupoort
[![latest version](https://img.shields.io/nuget/v/PacketSupoort)](https://www.nuget.org/packages/PacketSupoort)
[![downloads](https://img.shields.io/nuget/dt/PacketSupoort)](https://www.nuget.org/packages/PacketSupoort)

# OVERVIEW
0. [Print](#Print)
1. [PacketBuilder](#PacketBuilder)
2. [Append Extentions](#AppendExtentions)
3. [PacketCheckSum](#PacketCheckSum) **(feat. [Mythosia.Integrity](https://github.com/AJ-comp/Mythosia/tree/master/Mythosia.Integrity))**
4. [EndianPacket](#EndianPacket)
5. [bytearray-class(Serialization,Deserialization)](#bytearray<->class(Serialization,Deserialization)))

The current difference between **Extentions** and **PacketBuilder** is that Extentions supports the Chain Method, while **PacketBuilder** is intended to provide more functionality in the future.

## Print
1. Display() => only byte
2. DisplayAscii() => AsciiCode Byte
```csharp

var builder = new PacketBuilder ()
               .Append (0x40)
               .Append (0x41)
               .Append (0x42)
               .Append (0x43)
               .Append (0x44)
               .Append (0x45)
               .Build();

Console.WriteLine (builder.Display ());
Console.WriteLine (builder.DisplayAscii ());

// output

// 404142434445
// @ABCDE
```

## PacketBuilder
- Append Byte
```csharp
var builder = new PacketBuilder ()
               .Append (0x40)
               .Append (0x41)
               .Append (0x42)
               .Append (0x43)
               .Append (0x44)
               .Append (0x45)
               .Build();
```
- Append Byte Array
```csharp
var writer = new PacketBuilder ();
writer.Append(new List<byte>()
            {
            0x40,
            0x41,
            0x42,
            0x43,
            0x44,
            0x45,
            })
      .Build();
/* and
writer.Append(new byte[]
            {
            0x40,
            0x41,
            0x42,
            0x43,
            0x44,
            0x45,
            })
      .Build();
*/
```

## AppendExtentions
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
## PacketCheckSum
- There are two ways to do this
The first ErrorDetection method
``` csharp
var packet = pb
  .Append(0x01)  // CMD
  .Append(0x02)
  .Append(0x03)
  .Append(0x04)
  .Append(0x05)
  .ErrorDetection(Checksum8Type.Xor) 
  .Build();
// or
//   .ErrorDetection(Checksum8Type.Xor, start index);
// or
//   .ErrorDetection(Checksum8Type.Xor, start index, count); 
```
The second PointSave method
SavePoint can be used to extend beyond checksums to areas that need to be temporarily stored.
``` csharp
var packet = pb
  .Append(0x01)  // CMD
  .PointSaveStart("ChecksumPacking")
  .Append(0x02)
  .Append(0x03)
  .Append(0x04)
  .Append(0x05)
  .PointSaveEnd("ChecksumPacking");
  .Checksum("ChecksumPacking", Checksum8Type.Xor) // 8비트 체크섬이 삽입되는 위치
  .Build();

// extentions ex)
var savePacket = packet.GetSavePoint("ChecksumPacking");
```
## EndianPacket
You can create packets that match the endian type.
```csharp
short test = 0x0102;
 short testAdd = 0x0304;

 var littlEndianType = new PacketBuilder (); 

 var bigEndianType = new PacketBuilder (new PacketBuilderConfiguration ()
 {
     DefaultEndian = BytePacketSupport.Enums.Endian.BIG
 });

 var display1 = littlEndianType.Append (test)
                               .Append (testAdd)
                               .Build ();

 var display2 = bigEndianType.Append (test)
                             .Append (testAdd)
                             .Build ();

 Console.WriteLine ("display1 {0}", display1.Display ());
 Console.WriteLine ("display2 {0}", display2.Display ());
// output
// display1 02010403
// display2 01020304
```
For Append Extensions, the 
out of respect for developers' freedom to customize, you can set your own
```csharp
// Extentions 활용 시
short test = 0x0102;
byte[] abclittle = new byte[] { 0x01, 0x02 };
byte[] abcBig = new byte[] { 0x01, 0x02 };

// 정수형 Append 메서드 기본적으로 LittleEnidianType으로 동작합니다.
// Append (int intByte, bool isLittleEndian = true)

abclittle = abclittle.Append (test);
abcBig = abcBig.Append (test, false);


Console.WriteLine ("display1 {0}", abclittle.Display ());
Console.WriteLine ("display2 {0}", abcBig.Display ());

// output
// display1 01020201
// display2 01020102
```
## bytearray<->class(Serialization,Deserialization)
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
