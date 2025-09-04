# PacketSupoort

[![latest version](https://img.shields.io/nuget/v/PacketSupoort)](https://www.nuget.org/packages/PacketSupoort)
[![downloads](https://img.shields.io/nuget/dt/PacketSupoort)](https://www.nuget.org/packages/PacketSupoort)

**PacketSupoort**는 다양한 타입을 손쉽게 `Append` 하여 **byte 배열(Packet)** 을 만들고, 파싱할 수 있는 .NET 라이브러리입니다.

이 라이브러리는 `StringBuilder`에서 영감을 얻어,  
네트워크 패킷 · IoT 프로토콜 · 바이너리 파일 작성 등  
**바이트 배열 조작**이 필요한 곳에서 간결하고 안전한 코드를 제공합니다.

---

## ✨ 주요 특징
- **단일 `Append()` 메서드로 모든 타입 지원**  
  (byte, short, int, string, class …)
- **체인 메서드 방식** → 가독성 높은 코드
- **Endian 제어** (Little / Big Endian)
- **체크섬 계산** (Checksum8Type 지원)
- **클래스 직렬화/역직렬화** → byte 배열 <-> 객체 변환
- **기존 메서드(`AppendInt32`, `Appendint`, `@int`)도 호환 가능**  
  *(네임스페이스 분리로 유지)*

---

## 📦 설치

NuGet 패키지를 통해 설치할 수 있습니다.

```sh
dotnet add package PacketSupoort
```

## 🚀 빠른 시작 (Quick Start)
```csharp
using BytePacketSupport;

var builder = new PacketBuilder()
    .Append(0x01, 0x02, 0x03, 0x04, 0x05)
    .Build();

Console.WriteLine(builder.ToHexString());
// 출력: 0102030405
```
## 🧱 PacketBuilder 기본 사용법
### 정수추가
```csharp
var builder = new PacketBuilder()
    .Append(1234)            // int
    .Append((short)1234)     // short
    .Append((uint)1234)      // uint
    .Build();
```

### 문자열 추가
```csharp
var builder = new PacketBuilder()
    .Append("HELLO")         // 기본 ASCII
    .Build();
```
### 여러 바이트 한 번에 추가
```csharp
var builder = new PacketBuilder()
    .Append(0xAA, 0xBB, 0xCC)
    .Build();
```

### 🔁 Endian 제어
```csharp
short value = 0x0102;

// 기본: Little Endian
var littleEndianPacket = new PacketBuilder()
    .Append(value)
    .Build();

// Big Endian
var bigEndianPacket = new PacketBuilder(
    new PacketBuilderConfiguration() { DefaultEndian = Endian.BIG })
    .Append(value)
    .Build();
```

## 🧮 체크섬 (Checksum)
### 1) 인덱스 범위 지정 방식
```csharp
var packet = new PacketBuilder()
    .Append(0x01, 0x02, 0x03, 0x04)
    .Compute(Checksum8Type.Xor)  // 전체 구간 XOR 체크섬 추가
    .Build();
```
### 2) BeginSection / EndSection 방식
```csharp
var packet = new PacketBuilder()
    .Append(0x01) // CMD
    .BeginSection("ChecksumArea")
    .Append(0x02, 0x03, 0x04, 0x05)
    .EndSection("ChecksumArea")
    .Compute("ChecksumArea", Checksum8Type.Xor)
    .Build();
```

## 📦 클래스 직렬화/역직렬화
```csharp
public class TestPacket
{
    public int Value;
    [ByteSize(3)] public string Value1;
    [ByteSize(4)] public byte[] Data;
}

var packetData = PacketParse.Serialize(new TestPacket
{
    Value = 100,
    Value1 = "ABC",
    Data = new byte[] { 0x10, 0x11, 0x12, 0x13 }
});

var parsed = PacketParse.Deserialize<TestPacket>(packetData);
```
## 🕒 호환성 안내 (Versioning)

3.0부터는 Append() 하나로 타입을 자동 처리하는 방식을 권장합니다.

기존 메서드 (AppendInt32, Appendint, @int)는 삭제되지 않았으며
별도의 네임스페이스 참조 시 그대로 사용 가능합니다.

버전별 상세 변경점은 CHANGELOG
에서 확인하세요.

## 💡 설계 철학

PacketSupoort는 네트워크 프로그래밍을 위한 "문자열 빌더" 같은 역할을 목표로 합니다.
타입에 상관없이 Append() 메서드로 데이터를 이어 붙이고,
최종적으로 byte 배열을 얻는 직관적 인터페이스를 제공합니다.

---

<img src = "https://github.com/lukewire129/BytePacketSupport/assets/54387261/1a9028b0-ae1f-4f5f-82f7-18ecde0ca360" width="100" height="100">

"Icon made by Freepik from www.flaticon.com"
([Link](https://www.flaticon.com/free-icon/brick-wall_1887007?term=brick&related_id=1887007))
