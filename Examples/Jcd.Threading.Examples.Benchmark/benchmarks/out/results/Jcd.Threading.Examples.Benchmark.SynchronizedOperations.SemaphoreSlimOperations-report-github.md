```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-TMZHUX : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-AAPCYZ : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```
| Method                                 | Runtime              | Mean      | Error    | StdDev   | Ratio | RatioSD |
|--------------------------------------- |--------------------- |----------:|---------:|---------:|------:|--------:|
| UsingMutexValue_ReadValue              | .NET 8.0             |  31.31 ns | 0.105 ns | 0.062 ns |  1.00 |    0.00 |
| UsingMutexValue_ReadValue              | .NET Framework 4.6.2 |  64.94 ns | 1.141 ns | 0.679 ns |  2.07 |    0.02 |
|                                        |                      |           |          |          |       |         |
| UsingMutexValue_WriteValue             | .NET 8.0             |  31.48 ns | 0.128 ns | 0.067 ns |  1.00 |    0.00 |
| UsingMutexValue_WriteValue             | .NET Framework 4.6.2 |  64.74 ns | 1.198 ns | 0.713 ns |  2.05 |    0.02 |
|                                        |                      |           |          |          |       |         |
| UsingSemaphoreDirectly_ReadValue       | .NET 8.0             |  31.63 ns | 0.150 ns | 0.089 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_ReadValue       | .NET Framework 4.6.2 |  65.54 ns | 0.915 ns | 0.545 ns |  2.07 |    0.02 |
|                                        |                      |           |          |          |       |         |
| UsingSemaphoreDirectly_WriteValue      | .NET 8.0             |  31.49 ns | 0.076 ns | 0.040 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_WriteValue      | .NET Framework 4.6.2 |  65.83 ns | 1.326 ns | 0.877 ns |  2.09 |    0.03 |
|                                        |                      |           |          |          |       |         |
| UsingSemaphoreDirectly_ReadValueAsync  | .NET 8.0             |  37.54 ns | 0.191 ns | 0.114 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_ReadValueAsync  | .NET Framework 4.6.2 |  87.22 ns | 1.658 ns | 0.987 ns |  2.32 |    0.03 |
|                                        |                      |           |          |          |       |         |
| UsingSemaphoreDirectly_WriteValueAsync | .NET 8.0             |  37.81 ns | 0.296 ns | 0.176 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_WriteValueAsync | .NET Framework 4.6.2 |  86.51 ns | 1.569 ns | 0.933 ns |  2.29 |    0.03 |
|                                        |                      |           |          |          |       |         |
| UsingExtensions_ReadValue              | .NET 8.0             |  35.83 ns | 0.231 ns | 0.121 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue              | .NET Framework 4.6.2 |  69.24 ns | 0.390 ns | 0.204 ns |  1.93 |    0.01 |
|                                        |                      |           |          |          |       |         |
| UsingExtensions_WriteValue             | .NET 8.0             |  36.56 ns | 0.439 ns | 0.195 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue             | .NET Framework 4.6.2 |  73.77 ns | 0.220 ns | 0.131 ns |  2.02 |    0.01 |
|                                        |                      |           |          |          |       |         |
| UsingExtensions_ReadValueAsync         | .NET 8.0             |  55.39 ns | 0.644 ns | 0.337 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValueAsync         | .NET Framework 4.6.2 | 178.81 ns | 3.466 ns | 1.813 ns |  3.23 |    0.05 |
|                                        |                      |           |          |          |       |         |
| UsingExtensions_WriteValueAsync        | .NET 8.0             |  55.75 ns | 0.649 ns | 0.386 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValueAsync        | .NET Framework 4.6.2 | 176.85 ns | 1.556 ns | 0.926 ns |  3.17 |    0.03 |
