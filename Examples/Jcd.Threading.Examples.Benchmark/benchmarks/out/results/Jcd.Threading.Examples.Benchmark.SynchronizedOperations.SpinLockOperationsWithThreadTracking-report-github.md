```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-SWTUPK : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-VBTVTX : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=10  MinIterationCount=5  WarmupCount=1  

```
| Method                                           | Runtime              | Mean      | Error     | StdDev    | Ratio |
|------------------------------------------------- |--------------------- |----------:|----------:|----------:|------:|
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET 8.0             | 53.677 ns | 0.4500 ns | 0.1169 ns |  1.00 |
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET Framework 4.6.2 | 62.284 ns | 0.9293 ns | 0.3314 ns |  1.16 |
|                                                  |                      |           |           |           |       |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET 8.0             | 53.777 ns | 0.9494 ns | 0.2465 ns |  1.00 |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET Framework 4.6.2 | 61.749 ns | 1.2058 ns | 0.1866 ns |  1.15 |
|                                                  |                      |           |           |           |       |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET 8.0             | 59.299 ns | 1.1798 ns | 0.3064 ns |  1.00 |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET Framework 4.6.2 | 67.278 ns | 0.8457 ns | 0.2196 ns |  1.13 |
|                                                  |                      |           |           |           |       |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET 8.0             | 59.401 ns | 0.8925 ns | 0.2318 ns |  1.00 |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET Framework 4.6.2 | 66.986 ns | 0.4233 ns | 0.1099 ns |  1.13 |
|                                                  |                      |           |           |           |       |
| UsingExtensions_ReadValue                        | .NET 8.0             | 64.470 ns | 1.1680 ns | 0.4165 ns |  1.00 |
| UsingExtensions_ReadValue                        | .NET Framework 4.6.2 | 70.322 ns | 1.0232 ns | 0.2657 ns |  1.09 |
|                                                  |                      |           |           |           |       |
| UsingExtensions_WriteValue                       | .NET 8.0             | 60.888 ns | 1.1331 ns | 0.5031 ns |  1.00 |
| UsingExtensions_WriteValue                       | .NET Framework 4.6.2 | 67.675 ns | 0.9292 ns | 0.3314 ns |  1.11 |
|                                                  |                      |           |           |           |       |
| UsingSpinLockValue_ReadValue                     | .NET 8.0             |  9.208 ns | 0.1489 ns | 0.0531 ns |  1.00 |
| UsingSpinLockValue_ReadValue                     | .NET Framework 4.6.2 | 10.144 ns | 0.2169 ns | 0.0963 ns |  1.10 |
|                                                  |                      |           |           |           |       |
| UsingSpinLockValue_WriteValue                    | .NET 8.0             |  9.387 ns | 0.1318 ns | 0.0342 ns |  1.00 |
| UsingSpinLockValue_WriteValue                    | .NET Framework 4.6.2 | 10.595 ns | 0.1898 ns | 0.0993 ns |  1.12 |
