```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-YYFNSL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EBXDII : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```

| Method                                 | Runtime              |     Mean |    Error |   StdDev | Ratio | RatioSD |
|----------------------------------------|----------------------|---------:|---------:|---------:|------:|--------:|
| UsingSynchronizedValue_ReadValue       | .NET 8.0             | 19.52 ns | 0.564 ns | 0.373 ns |  1.00 |    0.00 |
| UsingSynchronizedValue_ReadValue       | .NET Framework 4.6.2 | 29.89 ns | 1.006 ns | 0.727 ns |  1.53 |    0.05 |
|                                        |                      |          |          |          |       |         |
| UsingSynchronizedValue_WriteValue      | .NET 8.0             | 19.85 ns | 0.420 ns | 0.250 ns |  1.00 |    0.00 |
| UsingSynchronizedValue_WriteValue      | .NET Framework 4.6.2 | 27.02 ns | 1.356 ns | 0.980 ns |  1.37 |    0.05 |
|                                        |                      |          |          |          |       |         |
| UsingSynchronizedValue_ReadValueAsync  | .NET 8.0             | 24.75 ns | 1.038 ns | 0.750 ns |  1.00 |    0.00 |
| UsingSynchronizedValue_ReadValueAsync  | .NET Framework 4.6.2 | 28.78 ns | 0.296 ns | 0.176 ns |  1.16 |    0.04 |
|                                        |                      |          |          |          |       |         |
| UsingSynchronizedValue_WriteValueAsync | .NET 8.0             | 22.55 ns | 0.969 ns | 0.700 ns |  1.00 |    0.00 |
| UsingSynchronizedValue_WriteValueAsync | .NET Framework 4.6.2 | 28.26 ns | 0.374 ns | 0.196 ns |  1.24 |    0.04 |
