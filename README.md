# PacketSupoort

[![latest version](https://img.shields.io/nuget/v/PacketSupoort)](https://www.nuget.org/packages/PacketSupoort)
[![downloads](https://img.shields.io/nuget/dt/PacketSupoort)](https://www.nuget.org/packages/PacketSupoort)


### Version 2.0.0 Update
#### Append Type 3(CLR, CSharp, Custom by @Dimohy)

|CLR|CSharp|Custom by @Dimohy|
|:---|:---|:---|
|AppendInt16|Appendshort|@short|
|AppendInt32|Appendint|@int|
|AppendInt64|Appendlong|@long|
|AppendUInt16|Appendushort|@ushort|
|AppendUInt32|Appenduint|@uint|
|AppendUInt64|Appendulong|@ulong|
|AppendByte|AppendByte|@byte|
|AppendBytes|AppendBytes|@bytes|
|AppendClass|AppendClass|@Class|
|AppendString|AppendString|@string|

#### Serialize&Deserialize of class attribute Type Add
- [Endian(Endian.Big)] or [Endian(Endian.Endian)]
  
  ![image](https://github.com/lukewire129/BytePacketSupport/assets/54387261/b8b8483b-dcc1-454f-8e64-b8e00a28e350)
  
# OVERVIEW
1. [Print](#Print)
2. [PacketBuilder](#PacketBuilder)
3. [Append Extentions](#AppendExtentions)
4. [PacketCheckSum](#PacketCheckSum) **(feat. [Mythosia.Integrity](https://github.com/AJ-comp/Mythosia/tree/master/Mythosia.Integrity))**
5. [EndianPacket](#EndianPacket)
6. [bytearray-class(Serialization,Deserialization)](#bytearray<->class(Serialization,Deserialization)))

The current difference between **Extentions** and **PacketBuilder** is that Extentions supports the Chain Method, while **PacketBuilder** is intended to provide more functionality in the future.

## Print
1. ToHexString() => only byte
2. GetString() => AsciiCode Byte // or GetString(Encoding)
```csharp
var builder = new PacketBuilder ()
               .AppendByte (0x40)
               .AppendByte (0x41)
               .AppendByte (0x42)
               .AppendByte (0x43)
               .AppendByte (0x44)
               .AppendByte (0x45)
               .Build();

Console.WriteLine (builder.ToHexString ());
Console.WriteLine (builder.GetString ());

// output

// 404142434445
// @ABCDE
```

## PacketBuilder
- Append Byte
  
  **CRL Type**
  ```csharp
  var builder = new PacketBuilder ()
               .AppendByte (0x40)
               .AppendByte (0x41)
               .AppendByte (0x42)
               .AppendByte (0x43)
               .AppendByte (0x44)
               .AppendByte (0x45)
               .Build();
  ```
  **csharp Type**
  ```csharp
  var builder = new PacketBuilder ()
               .AppendByte (0x40)
               .AppendByte (0x41)
               .AppendByte (0x42)
               .AppendByte (0x43)
               .AppendByte (0x44)
               .AppendByte (0x45)
               .Build();
  ```
  **CusotmType (feat. @Dimohy)**
  ```csharp
  var builder = new PacketBuilder ()
                 .@byte (0x40)
                 .@byte (0x41)
                 .@byte (0x42)
                 .@byte (0x43)
                 .@byte (0x44)
                 .@byte (0x45)
                 .Build();
  ```
- Append ByteArray
  
  **CRL Type**
  ```csharp
  byte[] AddData = new byte[]{0x40, 0x41, 0x42, 0x43, 0x44, 0x45};
  var builder = new PacketBuilder ()
               .AppendBytes (AddData)
               .Build();
  ```
  **csharp Type**
  ```csharp
  byte[] AddData = new byte[]{0x40, 0x41, 0x42, 0x43, 0x44, 0x45};
  var builder = new PacketBuilder ()
               .AppendBytes (AddData)
               .Build();
  ```
  **CusotmType (feat. @Dimohy)**
  ```csharp
  byte[] AddData = new byte[]{0x40, 0x41, 0x42, 0x43, 0x44, 0x45};
  var builder = new PacketBuilder ()
                 .@bytes (AddData)
                 .Build();
  ```
## AppendExtentions 
- byte + byte array

  **CRL Type**
  ``` csharp
  byte[] summaryByts;
  byte testByte = 0x51;
  byte[] addBytes = new byte[]{0x52, 0x53}; // or  List<byte> addBytes = new List<byte>(){0x52, 0x53};
  summaryByts = testByte.AppendBytes(addBytes); 
  ```
  **csharp Type**
  ``` csharp
  byte[] summaryByts;
  byte testByte = 0x51;
  byte[] addBytes = new byte[]{0x52, 0x53}; // or  List<byte> addBytes = new List<byte>(){0x52, 0x53};
  summaryByts = testByte.AppendBytes(addBytes);
  ```
  **CusotmType (feat. @Dimohy)**
  ``` csharp
  byte[] summaryByts;
  byte testByte = 0x51;
  byte[] addBytes = new byte[]{0x52, 0x53}; // or  List<byte> addBytes = new List<byte>(){0x52, 0x53};
  summaryByts = testByte.@bytes(addBytes);
  ```
## PacketCheckSum
- There are two ways to do this
The first ErrorDetection method
``` csharp
var packet = pb
  .@byte(0x01)  // CMD
  .@byte(0x02)
  .@byte(0x03)
  .@byte(0x04)
  .@byte(0x05)
  .Compute(Checksum8Type.Xor) 
  .Build();
// or
//   .Compute(Checksum8Type.Xor, start index);
// or
//   .Compute(Checksum8Type.Xor, start index, count); 
```
The second PointSave method
SavePoint can be used to extend beyond checksums to areas that need to be temporarily stored.
``` csharp
var packet = pb
  .@byte(0x01)  // CMD
  .BeginSection("ChecksumPacking")
  .@byte(0x02)
  .@byte(0x03)
  .@byte(0x04)
  .@byte(0x05)
  .EndSection("ChecksumPacking");
  .Compute("ChecksumPacking", Checksum8Type.Xor) // 8비트 체크섬이 삽입되는 위치
  .Build();

// extentions ex)
var savePacket = packet.GetSection("ChecksumPacking");
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

 var display1 = littlEndianType.@short (test)
                               .@short (testAdd)
                               .Build ();

 var display2 = bigEndianType.@short (test)
                             .@short (testAdd)
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
// @int (int intByte, bool isLittleEndian = true)

abclittle = abclittle.@short (test);
abcBig = abcBig.@short (test, false);


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
    var aaa = PacketParse.Deserialize<Test2Packet> (test);

    var abc  = PacketParse.Serialize (aaa);
}
```

---

<img src = "https://github.com/lukewire129/BytePacketSupport/assets/54387261/1a9028b0-ae1f-4f5f-82f7-18ecde0ca360" width="100" height="100">

"Icon made by Freepik from www.flaticon.com"
([Link](https://www.flaticon.com/free-icon/brick-wall_1887007?term=brick&related_id=1887007))
