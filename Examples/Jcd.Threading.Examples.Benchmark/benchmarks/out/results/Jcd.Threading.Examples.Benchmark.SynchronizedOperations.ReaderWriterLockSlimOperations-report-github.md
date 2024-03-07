```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-SWTUPK : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-VBTVTX : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=10  MinIterationCount=5  WarmupCount=1  

```
| Method                          | Runtime              | Mean     | Error    | StdDev   | Ratio | RatioSD |
|-------------------------------- |--------------------- |---------:|---------:|---------:|------:|--------:|
| DirectCalls_ReadValue           | .NET 8.0             | 19.32 ns | 0.544 ns | 0.360 ns |  1.00 |    0.00 |
| DirectCalls_ReadValue           | .NET Framework 4.6.2 | 39.48 ns | 0.808 ns | 0.535 ns |  2.04 |    0.05 |
|                                 |                      |          |          |          |       |         |
| DirectCalls_WriteValue          | .NET 8.0             | 17.98 ns | 0.648 ns | 0.428 ns |  1.00 |    0.00 |
| DirectCalls_WriteValue          | .NET Framework 4.6.2 | 29.63 ns | 0.589 ns | 0.389 ns |  1.65 |    0.05 |
|                                 |                      |          |          |          |       |         |
| UsingExtensions_ReadValue       | .NET 8.0             | 24.21 ns | 1.844 ns | 1.097 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue       | .NET Framework 4.6.2 | 39.84 ns | 0.941 ns | 0.622 ns |  1.65 |    0.08 |
|                                 |                      |          |          |          |       |         |
| UsingExtensions_WriteValue      | .NET 8.0             | 21.65 ns | 0.534 ns | 0.353 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue      | .NET Framework 4.6.2 | 29.40 ns | 1.082 ns | 0.715 ns |  1.36 |    0.03 |
|                                 |                      |          |          |          |       |         |
| UsingExtensions_ReadValueAsync  | .NET 8.0             | 35.21 ns | 1.384 ns | 0.823 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValueAsync  | .NET Framework 4.6.2 | 80.08 ns | 3.600 ns | 2.381 ns |  2.26 |    0.10 |
|                                 |                      |          |          |          |       |         |
| UsingExtensions_WriteValueAsync | .NET 8.0             | 32.63 ns | 0.650 ns | 0.340 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValueAsync | .NET Framework 4.6.2 | 70.12 ns | 3.073 ns | 1.829 ns |  2.16 |    0.04 |
