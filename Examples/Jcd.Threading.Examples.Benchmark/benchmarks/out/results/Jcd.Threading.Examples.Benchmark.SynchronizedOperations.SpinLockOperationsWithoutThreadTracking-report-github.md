```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-YYFNSL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EBXDII : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```
| Method                                           | Runtime              | Mean      | Error     | StdDev    | Ratio | RatioSD |
|------------------------------------------------- |--------------------- |----------:|----------:|----------:|------:|--------:|
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET 8.0             |  9.539 ns | 0.8073 ns | 0.5339 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET Framework 4.6.2 |  9.874 ns | 0.2133 ns | 0.1543 ns |  1.04 |    0.06 |
|                                                  |                      |           |           |           |       |         |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET 8.0             |  9.075 ns | 0.1484 ns | 0.0776 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET Framework 4.6.2 |  9.800 ns | 0.1609 ns | 0.0842 ns |  1.08 |    0.01 |
|                                                  |                      |           |           |           |       |         |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET 8.0             | 14.496 ns | 0.0604 ns | 0.0268 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET Framework 4.6.2 | 17.788 ns | 2.3220 ns | 1.6790 ns |  1.23 |    0.11 |
|                                                  |                      |           |           |           |       |         |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET 8.0             | 14.662 ns | 0.2218 ns | 0.1320 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET Framework 4.6.2 | 16.747 ns | 1.3926 ns | 0.9211 ns |  1.13 |    0.06 |
|                                                  |                      |           |           |           |       |         |
| UsingExtensions_ReadValue                        | .NET 8.0             | 14.911 ns | 0.4897 ns | 0.3541 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue                        | .NET Framework 4.6.2 | 15.698 ns | 0.3598 ns | 0.2602 ns |  1.05 |    0.03 |
|                                                  |                      |           |           |           |       |         |
| UsingExtensions_WriteValue                       | .NET 8.0             | 13.345 ns | 0.8885 ns | 0.5287 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue                       | .NET Framework 4.6.2 | 13.273 ns | 0.3336 ns | 0.2207 ns |  1.00 |    0.03 |
|                                                  |                      |           |           |           |       |         |
| UsingSpinLockValue_ReadValue                     | .NET 8.0             |  8.877 ns | 0.2588 ns | 0.1872 ns |  1.00 |    0.00 |
| UsingSpinLockValue_ReadValue                     | .NET Framework 4.6.2 | 10.754 ns | 0.6771 ns | 0.4478 ns |  1.21 |    0.06 |
|                                                  |                      |           |           |           |       |         |
| UsingSpinLockValue_WriteValue                    | .NET 8.0             | 10.226 ns | 0.7400 ns | 0.4895 ns |  1.00 |    0.00 |
| UsingSpinLockValue_WriteValue                    | .NET Framework 4.6.2 | 10.510 ns | 0.3018 ns | 0.1996 ns |  1.03 |    0.05 |
