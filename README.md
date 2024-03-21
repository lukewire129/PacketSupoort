### BytePacketSupport

## use
1. PacketWriter class
2. Extentions

## output
1. Display() => only byte
2. DisplayAscii() => AsciiCode Byte

   
1. PacketWriter 
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

2. Extentions
    - byte + byte[]
    ```
    byte[] summaryByts;
    byte testByte = 0x51;

    summaryByts = testByte.AppendBytes(new byte[]{
                                                  0x52,
                                                  0x53
                                                });
    Console.WriteLine (summaryByts.Display ());
    Console.WriteLine (summaryByts.DisplayAscii ());

    // output
    
    // 50515253
    // PQRS
    ```

    
