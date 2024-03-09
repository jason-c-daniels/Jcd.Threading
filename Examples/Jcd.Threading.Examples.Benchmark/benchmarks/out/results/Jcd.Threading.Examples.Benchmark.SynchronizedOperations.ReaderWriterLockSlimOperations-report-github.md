```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-TMZHUX : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-AAPCYZ : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```
| Method                          | Runtime              | Mean      | Error    | StdDev   | Ratio | RatioSD |
|-------------------------------- |--------------------- |----------:|---------:|---------:|------:|--------:|
| DirectCalls_ReadValue           | .NET 8.0             |  19.71 ns | 0.371 ns | 0.194 ns |  1.00 |    0.00 |
| DirectCalls_ReadValue           | .NET Framework 4.6.2 |  39.97 ns | 0.195 ns | 0.116 ns |  2.03 |    0.02 |
|                                 |                      |           |          |          |       |         |
| DirectCalls_WriteValue          | .NET 8.0             |  18.14 ns | 0.606 ns | 0.438 ns |  1.00 |    0.00 |
| DirectCalls_WriteValue          | .NET Framework 4.6.2 |  29.28 ns | 0.302 ns | 0.180 ns |  1.61 |    0.04 |
|                                 |                      |           |          |          |       |         |
| UsingExtensions_ReadValue       | .NET 8.0             |  27.44 ns | 1.851 ns | 1.338 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue       | .NET Framework 4.6.2 |  36.09 ns | 0.820 ns | 0.593 ns |  1.32 |    0.07 |
|                                 |                      |           |          |          |       |         |
| UsingExtensions_WriteValue      | .NET 8.0             |  24.98 ns | 0.678 ns | 0.449 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue      | .NET Framework 4.6.2 |  36.32 ns | 0.837 ns | 0.605 ns |  1.45 |    0.04 |
|                                 |                      |           |          |          |       |         |
| UsingExtensions_ReadValueAsync  | .NET 8.0             |  41.16 ns | 1.034 ns | 0.747 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValueAsync  | .NET Framework 4.6.2 | 127.39 ns | 2.547 ns | 1.842 ns |  3.10 |    0.08 |
|                                 |                      |           |          |          |       |         |
| UsingExtensions_WriteValueAsync | .NET 8.0             |  42.24 ns | 0.730 ns | 0.434 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValueAsync | .NET Framework 4.6.2 | 126.62 ns | 2.362 ns | 1.563 ns |  2.99 |    0.04 |
