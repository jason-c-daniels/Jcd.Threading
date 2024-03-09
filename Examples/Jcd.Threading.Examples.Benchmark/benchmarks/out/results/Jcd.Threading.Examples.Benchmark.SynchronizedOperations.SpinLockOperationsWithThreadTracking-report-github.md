```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EDIIFL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-DEBPPF : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```
| Method                                           | Runtime              | Mean     | Error    | StdDev   | Ratio | RatioSD |
|------------------------------------------------- |--------------------- |---------:|---------:|---------:|------:|--------:|
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET 8.0             | 56.66 ns | 4.286 ns | 3.099 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET Framework 4.6.2 | 61.40 ns | 0.972 ns | 0.508 ns |  1.07 |    0.06 |
|                                                  |                      |          |          |          |       |         |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET 8.0             | 54.23 ns | 1.024 ns | 0.536 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET Framework 4.6.2 | 63.71 ns | 3.484 ns | 2.519 ns |  1.17 |    0.04 |
|                                                  |                      |          |          |          |       |         |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET 8.0             | 60.89 ns | 1.471 ns | 1.064 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET Framework 4.6.2 | 68.68 ns | 4.684 ns | 3.387 ns |  1.13 |    0.06 |
|                                                  |                      |          |          |          |       |         |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET 8.0             | 59.36 ns | 0.956 ns | 0.569 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET Framework 4.6.2 | 68.10 ns | 1.696 ns | 1.122 ns |  1.14 |    0.01 |
|                                                  |                      |          |          |          |       |         |
| UsingExtensions_ReadValue                        | .NET 8.0             | 63.18 ns | 2.969 ns | 1.964 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue                        | .NET Framework 4.6.2 | 67.60 ns | 1.995 ns | 1.187 ns |  1.08 |    0.04 |
|                                                  |                      |          |          |          |       |         |
| UsingExtensions_WriteValue                       | .NET 8.0             | 60.17 ns | 1.597 ns | 1.155 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue                       | .NET Framework 4.6.2 | 65.25 ns | 1.593 ns | 1.151 ns |  1.08 |    0.03 |
|                                                  |                      |          |          |          |       |         |
| UsingSpinLockValue_ReadValue                     | .NET 8.0             | 54.36 ns | 1.054 ns | 0.627 ns |  1.00 |    0.00 |
| UsingSpinLockValue_ReadValue                     | .NET Framework 4.6.2 | 61.64 ns | 1.066 ns | 0.474 ns |  1.13 |    0.02 |
|                                                  |                      |          |          |          |       |         |
| UsingSpinLockValue_WriteValue                    | .NET 8.0             | 54.99 ns | 1.013 ns | 0.530 ns |  1.00 |    0.00 |
| UsingSpinLockValue_WriteValue                    | .NET Framework 4.6.2 | 63.10 ns | 0.723 ns | 0.378 ns |  1.15 |    0.01 |
