```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EDIIFL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-DEBPPF : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```

| Method                                           | Runtime              |      Mean |     Error |    StdDev | Ratio | RatioSD |
|--------------------------------------------------|----------------------|----------:|----------:|----------:|------:|--------:|
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET 8.0             |  8.956 ns | 0.0595 ns | 0.0311 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_ReadValue_NoMemoryBarrier    | .NET Framework 4.6.2 |  9.848 ns | 0.3701 ns | 0.2448 ns |  1.11 |    0.03 |
|                                                  |                      |           |           |           |       |         |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET 8.0             |  9.273 ns | 0.6107 ns | 0.4416 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_WriteValue_NoMemoryBarrier   | .NET Framework 4.6.2 |  9.637 ns | 0.0343 ns | 0.0180 ns |  1.07 |    0.01 |
|                                                  |                      |           |           |           |       |         |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET 8.0             | 14.751 ns | 0.3940 ns | 0.2849 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_ReadValue_WithMemoryBarrier  | .NET Framework 4.6.2 | 15.650 ns | 0.2983 ns | 0.1560 ns |  1.06 |    0.02 |
|                                                  |                      |           |           |           |       |         |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET 8.0             | 14.486 ns | 0.0523 ns | 0.0232 ns |  1.00 |    0.00 |
| DirectSpinLockCalls_WriteValue_WithMemoryBarrier | .NET Framework 4.6.2 | 15.875 ns | 0.4991 ns | 0.3301 ns |  1.11 |    0.02 |
|                                                  |                      |           |           |           |       |         |
| UsingExtensions_ReadValue                        | .NET 8.0             | 14.395 ns | 0.1369 ns | 0.0815 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue                        | .NET Framework 4.6.2 | 15.451 ns | 0.3164 ns | 0.1883 ns |  1.07 |    0.02 |
|                                                  |                      |           |           |           |       |         |
| UsingExtensions_WriteValue                       | .NET 8.0             | 12.868 ns | 0.4760 ns | 0.3149 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue                       | .NET Framework 4.6.2 | 13.246 ns | 0.3984 ns | 0.2881 ns |  1.03 |    0.04 |
|                                                  |                      |           |           |           |       |         |
| UsingSpinLockValue_ReadValue                     | .NET 8.0             |  9.122 ns | 0.0843 ns | 0.0374 ns |  1.00 |    0.00 |
| UsingSpinLockValue_ReadValue                     | .NET Framework 4.6.2 | 10.181 ns | 0.3329 ns | 0.2407 ns |  1.10 |    0.02 |
|                                                  |                      |           |           |           |       |         |
| UsingSpinLockValue_WriteValue                    | .NET 8.0             |  9.510 ns | 0.3062 ns | 0.2025 ns |  1.00 |    0.00 |
| UsingSpinLockValue_WriteValue                    | .NET Framework 4.6.2 | 10.228 ns | 0.1798 ns | 0.1070 ns |  1.07 |    0.02 |
