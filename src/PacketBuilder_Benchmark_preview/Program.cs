using BenchmarkDotNet.Running;
using BytePacketSupport;
using PacketBuilder_Benchmark_preview;

// dotnet run -project .\PacketBuilder_Benchmark_preview.csproj -c Release
var summary = BenchmarkRunner.Run<MyBenchmarkTest> ();
