```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-TMZHUX : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-AAPCYZ : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```
| Method                                           | Runtime              | Mean     | Error    | StdDev   | Ratio | RatioSD |
|------------------------------------------------- |--------------------- |---------:|---------:|---------:|------:|--------:|
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET 8.0             | 53.63 ns | 0.125 ns | 0.074 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET Framework 4.6.2 | 62.33 ns | 1.606 ns | 1.062 ns |  1.16 |    0.02 |
|                                                  |                      |          |          |          |       |         |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET 8.0             | 53.67 ns | 0.129 ns | 0.077 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET Framework 4.6.2 | 62.86 ns | 1.110 ns | 0.661 ns |  1.17 |    0.01 |
|                                                  |                      |          |          |          |       |         |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET 8.0             | 61.42 ns | 1.009 ns | 0.528 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET Framework 4.6.2 | 67.43 ns | 1.033 ns | 0.615 ns |  1.10 |    0.01 |
|                                                  |                      |          |          |          |       |         |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET 8.0             | 59.24 ns | 0.258 ns | 0.135 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET Framework 4.6.2 | 66.92 ns | 1.299 ns | 0.773 ns |  1.13 |    0.01 |
|                                                  |                      |          |          |          |       |         |
| UsingExtensions_ReadValue                        | .NET 8.0             | 61.97 ns | 1.223 ns | 0.809 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue                        | .NET Framework 4.6.2 | 67.36 ns | 1.602 ns | 1.159 ns |  1.09 |    0.03 |
|                                                  |                      |          |          |          |       |         |
| UsingExtensions_WriteValue                       | .NET 8.0             | 58.56 ns | 0.358 ns | 0.159 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue                       | .NET Framework 4.6.2 | 64.54 ns | 1.260 ns | 0.750 ns |  1.11 |    0.01 |
|                                                  |                      |          |          |          |       |         |
| UsingSpinLockValue_ReadValue                     | .NET 8.0             | 54.79 ns | 0.882 ns | 0.525 ns |  1.00 |    0.00 |
| UsingSpinLockValue_ReadValue                     | .NET Framework 4.6.2 | 62.50 ns | 1.103 ns | 0.730 ns |  1.14 |    0.02 |
|                                                  |                      |          |          |          |       |         |
| UsingSpinLockValue_WriteValue                    | .NET 8.0             | 56.17 ns | 0.877 ns | 0.522 ns |  1.00 |    0.00 |
| UsingSpinLockValue_WriteValue                    | .NET Framework 4.6.2 | 61.60 ns | 0.376 ns | 0.224 ns |  1.10 |    0.01 |
