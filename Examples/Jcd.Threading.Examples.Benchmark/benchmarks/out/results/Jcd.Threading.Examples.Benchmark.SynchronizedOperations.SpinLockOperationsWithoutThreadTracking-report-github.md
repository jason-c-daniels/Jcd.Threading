```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-SWTUPK : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-VBTVTX : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=10  MinIterationCount=5  WarmupCount=1  

```
| Method                                           | Runtime              | Mean      | Error     | StdDev    | Ratio | RatioSD |
|------------------------------------------------- |--------------------- |----------:|----------:|----------:|------:|--------:|
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET 8.0             |  9.043 ns | 0.0859 ns | 0.0223 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET Framework 4.6.2 |  9.696 ns | 0.1640 ns | 0.0426 ns |  1.07 |    0.01 |
|                                                  |                      |           |           |           |       |         |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET 8.0             |  9.103 ns | 0.1496 ns | 0.0388 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET Framework 4.6.2 |  9.861 ns | 0.3530 ns | 0.2335 ns |  1.08 |    0.03 |
|                                                  |                      |           |           |           |       |         |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET 8.0             | 14.578 ns | 0.2108 ns | 0.0326 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET Framework 4.6.2 | 15.886 ns | 0.2014 ns | 0.0523 ns |  1.09 |    0.01 |
|                                                  |                      |           |           |           |       |         |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET 8.0             | 14.676 ns | 0.1991 ns | 0.0517 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET Framework 4.6.2 | 15.847 ns | 0.2985 ns | 0.1064 ns |  1.08 |    0.01 |
|                                                  |                      |           |           |           |       |         |
| UsingExtensions_ReadValue                        | .NET 8.0             | 18.169 ns | 2.3625 ns | 1.5626 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue                        | .NET Framework 4.6.2 | 16.878 ns | 0.3275 ns | 0.1713 ns |  0.92 |    0.08 |
|                                                  |                      |           |           |           |       |         |
| UsingExtensions_WriteValue                       | .NET 8.0             | 14.116 ns | 0.3013 ns | 0.1338 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue                       | .NET Framework 4.6.2 | 14.557 ns | 0.2601 ns | 0.1155 ns |  1.03 |    0.01 |
|                                                  |                      |           |           |           |       |         |
| UsingSpinLockValue_ReadValue                     | .NET 8.0             |  9.156 ns | 0.1896 ns | 0.0492 ns |  1.00 |    0.00 |
| UsingSpinLockValue_ReadValue                     | .NET Framework 4.6.2 |  9.760 ns | 0.1552 ns | 0.0689 ns |  1.07 |    0.01 |
|                                                  |                      |           |           |           |       |         |
| UsingSpinLockValue_WriteValue                    | .NET 8.0             |  9.496 ns | 0.0583 ns | 0.0090 ns |  1.00 |    0.00 |
| UsingSpinLockValue_WriteValue                    | .NET Framework 4.6.2 | 10.505 ns | 0.2254 ns | 0.1001 ns |  1.11 |    0.01 |
