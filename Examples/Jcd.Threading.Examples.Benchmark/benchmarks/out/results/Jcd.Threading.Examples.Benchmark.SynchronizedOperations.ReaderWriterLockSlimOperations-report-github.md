```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EDIIFL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-DEBPPF : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```

| Method                          | Runtime              |      Mean |    Error |   StdDev | Ratio | RatioSD |
|---------------------------------|----------------------|----------:|---------:|---------:|------:|--------:|
| DirectCalls_ReadValue           | .NET 8.0             |  19.30 ns | 0.456 ns | 0.330 ns |  1.00 |    0.00 |
| DirectCalls_ReadValue           | .NET Framework 4.6.2 |  39.98 ns | 1.143 ns | 0.756 ns |  2.07 |    0.05 |
|                                 |                      |           |          |          |       |         |
| DirectCalls_WriteValue          | .NET 8.0             |  17.92 ns | 0.475 ns | 0.343 ns |  1.00 |    0.00 |
| DirectCalls_WriteValue          | .NET Framework 4.6.2 |  29.32 ns | 0.349 ns | 0.155 ns |  1.63 |    0.04 |
|                                 |                      |           |          |          |       |         |
| UsingExtensions_ReadValue       | .NET 8.0             |  26.96 ns | 2.599 ns | 1.719 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue       | .NET Framework 4.6.2 |  36.15 ns | 1.112 ns | 0.804 ns |  1.35 |    0.10 |
|                                 |                      |           |          |          |       |         |
| UsingExtensions_WriteValue      | .NET 8.0             |  24.19 ns | 1.069 ns | 0.707 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue      | .NET Framework 4.6.2 |  35.46 ns | 0.909 ns | 0.657 ns |  1.47 |    0.05 |
|                                 |                      |           |          |          |       |         |
| UsingExtensions_ReadValueAsync  | .NET 8.0             |  41.58 ns | 1.009 ns | 0.601 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValueAsync  | .NET Framework 4.6.2 | 125.89 ns | 2.895 ns | 2.093 ns |  3.04 |    0.06 |
|                                 |                      |           |          |          |       |         |
| UsingExtensions_WriteValueAsync | .NET 8.0             |  39.82 ns | 0.738 ns | 0.386 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValueAsync | .NET Framework 4.6.2 | 125.34 ns | 2.343 ns | 1.394 ns |  3.15 |    0.04 |
