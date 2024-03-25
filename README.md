### BytePacketSupport

## use
1. PacketBuilder
2. Append Extentions
3. PacketCheckSum(feat. [Mythosia.Integrity](https://github.com/AJ-comp/Mythosia/tree/master/Mythosia.Integrity))
4. bytearray - class (Serialization, Deserialization)

The current difference between **Extentions** and **PacketBuilder** is that Extentions supports the Chain Method, while **PacketBuilder** is intended to provide more functionality in the future.

## output print
1. Display() => only byte
2. DisplayAscii() => AsciiCode Byte


## 0. output print
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

## 1. PacketBuilder
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
## 3. PacketCheckSum(feat. [Mythosia.Integrity](https://github.com/AJ-comp/Mythosia/tree/master/Mythosia.Integrity))
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
## 4. bytearray - class (Serialization, Deserialization)
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
