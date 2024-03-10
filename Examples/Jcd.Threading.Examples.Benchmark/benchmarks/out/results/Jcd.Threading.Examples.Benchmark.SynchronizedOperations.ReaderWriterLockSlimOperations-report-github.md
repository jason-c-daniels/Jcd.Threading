```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-YYFNSL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EBXDII : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```

| Method                          | Runtime              |      Mean |    Error |   StdDev | Ratio | RatioSD |
|---------------------------------|----------------------|----------:|---------:|---------:|------:|--------:|
| DirectCalls_ReadValue           | .NET 8.0             |  19.50 ns | 0.691 ns | 0.499 ns |  1.00 |    0.00 |
| DirectCalls_ReadValue           | .NET Framework 4.6.2 |  39.70 ns | 0.768 ns | 0.457 ns |  2.04 |    0.04 |
|                                 |                      |           |          |          |       |         |
| DirectCalls_WriteValue          | .NET 8.0             |  17.83 ns | 0.311 ns | 0.163 ns |  1.00 |    0.00 |
| DirectCalls_WriteValue          | .NET Framework 4.6.2 |  30.13 ns | 0.874 ns | 0.632 ns |  1.68 |    0.03 |
|                                 |                      |           |          |          |       |         |
| UsingExtensions_ReadValue       | .NET 8.0             |  25.81 ns | 0.676 ns | 0.489 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue       | .NET Framework 4.6.2 |  45.51 ns | 0.572 ns | 0.299 ns |  1.76 |    0.04 |
|                                 |                      |           |          |          |       |         |
| UsingExtensions_WriteValue      | .NET 8.0             |  23.92 ns | 0.251 ns | 0.131 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue      | .NET Framework 4.6.2 |  36.54 ns | 1.033 ns | 0.747 ns |  1.53 |    0.04 |
|                                 |                      |           |          |          |       |         |
| UsingExtensions_ReadValueAsync  | .NET 8.0             |  40.90 ns | 0.517 ns | 0.308 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValueAsync  | .NET Framework 4.6.2 | 129.47 ns | 3.833 ns | 2.535 ns |  3.16 |    0.04 |
|                                 |                      |           |          |          |       |         |
| UsingExtensions_WriteValueAsync | .NET 8.0             |  41.31 ns | 2.305 ns | 1.666 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValueAsync | .NET Framework 4.6.2 | 127.37 ns | 5.197 ns | 3.758 ns |  3.09 |    0.16 |
