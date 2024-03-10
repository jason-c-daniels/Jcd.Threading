```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-YYFNSL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EBXDII : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```
| Method                                           | Runtime              | Mean     | Error    | StdDev   | Ratio | RatioSD |
|------------------------------------------------- |--------------------- |---------:|---------:|---------:|------:|--------:|
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET 8.0             | 55.12 ns | 1.038 ns | 0.618 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET Framework 4.6.2 | 62.04 ns | 0.302 ns | 0.134 ns |  1.12 |    0.01 |
|                                                  |                      |          |          |          |       |         |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET 8.0             | 53.90 ns | 0.439 ns | 0.195 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET Framework 4.6.2 | 61.79 ns | 0.469 ns | 0.245 ns |  1.15 |    0.00 |
|                                                  |                      |          |          |          |       |         |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET 8.0             | 58.94 ns | 0.394 ns | 0.234 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET Framework 4.6.2 | 66.97 ns | 0.442 ns | 0.231 ns |  1.14 |    0.01 |
|                                                  |                      |          |          |          |       |         |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET 8.0             | 59.16 ns | 0.540 ns | 0.282 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET Framework 4.6.2 | 66.95 ns | 0.669 ns | 0.398 ns |  1.13 |    0.01 |
|                                                  |                      |          |          |          |       |         |
| UsingExtensions_ReadValue                        | .NET 8.0             | 62.38 ns | 0.383 ns | 0.200 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue                        | .NET Framework 4.6.2 | 68.56 ns | 1.301 ns | 0.681 ns |  1.10 |    0.01 |
|                                                  |                      |          |          |          |       |         |
| UsingExtensions_WriteValue                       | .NET 8.0             | 59.70 ns | 0.578 ns | 0.344 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue                       | .NET Framework 4.6.2 | 65.47 ns | 0.712 ns | 0.424 ns |  1.10 |    0.01 |
|                                                  |                      |          |          |          |       |         |
| UsingSpinLockValue_ReadValue                     | .NET 8.0             | 54.35 ns | 0.134 ns | 0.059 ns |  1.00 |    0.00 |
| UsingSpinLockValue_ReadValue                     | .NET Framework 4.6.2 | 63.55 ns | 0.995 ns | 0.592 ns |  1.17 |    0.01 |
|                                                  |                      |          |          |          |       |         |
| UsingSpinLockValue_WriteValue                    | .NET 8.0             | 54.70 ns | 0.381 ns | 0.227 ns |  1.00 |    0.00 |
| UsingSpinLockValue_WriteValue                    | .NET Framework 4.6.2 | 63.43 ns | 1.272 ns | 0.920 ns |  1.16 |    0.02 |
