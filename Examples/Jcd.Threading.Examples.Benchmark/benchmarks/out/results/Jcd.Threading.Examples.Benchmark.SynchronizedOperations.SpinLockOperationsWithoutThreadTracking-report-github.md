```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-TMZHUX : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-AAPCYZ : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```
| Method                                           | Runtime              | Mean      | Error     | StdDev    | Ratio |
|------------------------------------------------- |--------------------- |----------:|----------:|----------:|------:|
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET 8.0             |  8.930 ns | 0.0452 ns | 0.0269 ns |  1.00 |
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET Framework 4.6.2 |  9.548 ns | 0.0518 ns | 0.0308 ns |  1.07 |
|                                                  |                      |           |           |           |       |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET 8.0             |  8.975 ns | 0.0254 ns | 0.0151 ns |  1.00 |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET Framework 4.6.2 |  9.574 ns | 0.0236 ns | 0.0140 ns |  1.07 |
|                                                  |                      |           |           |           |       |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET 8.0             | 14.385 ns | 0.0805 ns | 0.0421 ns |  1.00 |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET Framework 4.6.2 | 15.501 ns | 0.0895 ns | 0.0532 ns |  1.08 |
|                                                  |                      |           |           |           |       |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET 8.0             | 14.465 ns | 0.0637 ns | 0.0379 ns |  1.00 |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET Framework 4.6.2 | 15.509 ns | 0.0765 ns | 0.0455 ns |  1.07 |
|                                                  |                      |           |           |           |       |
| UsingExtensions_ReadValue                        | .NET 8.0             | 14.360 ns | 0.1674 ns | 0.0996 ns |  1.00 |
| UsingExtensions_ReadValue                        | .NET Framework 4.6.2 | 15.449 ns | 0.1202 ns | 0.0629 ns |  1.08 |
|                                                  |                      |           |           |           |       |
| UsingExtensions_WriteValue                       | .NET 8.0             | 12.401 ns | 0.0504 ns | 0.0224 ns |  1.00 |
| UsingExtensions_WriteValue                       | .NET Framework 4.6.2 | 13.127 ns | 0.0927 ns | 0.0552 ns |  1.06 |
|                                                  |                      |           |           |           |       |
| UsingSpinLockValue_ReadValue                     | .NET 8.0             |  9.024 ns | 0.0818 ns | 0.0487 ns |  1.00 |
| UsingSpinLockValue_ReadValue                     | .NET Framework 4.6.2 |  9.835 ns | 0.1127 ns | 0.0671 ns |  1.09 |
|                                                  |                      |           |           |           |       |
| UsingSpinLockValue_WriteValue                    | .NET 8.0             |  9.360 ns | 0.0470 ns | 0.0280 ns |  1.00 |
| UsingSpinLockValue_WriteValue                    | .NET Framework 4.6.2 | 10.301 ns | 0.1071 ns | 0.0637 ns |  1.10 |
