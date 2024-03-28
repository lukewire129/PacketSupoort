using BenchmarkDotNet.Running;
using BytePacketSupport;
using PacketBuilder_Benchmark;

//dotnet run -project .\PacketBuilder_Benchmark.csproj -c Release
var summary = BenchmarkRunner.Run<MyBenchmarkTest> ();
