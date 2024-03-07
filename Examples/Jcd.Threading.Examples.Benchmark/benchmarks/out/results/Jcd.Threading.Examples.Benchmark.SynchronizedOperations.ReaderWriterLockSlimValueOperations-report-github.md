```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-SWTUPK : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-VBTVTX : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=10  MinIterationCount=5  WarmupCount=1  

```

| Method                                 | Runtime              |     Mean |    Error |   StdDev | Ratio | RatioSD |
|----------------------------------------|----------------------|---------:|---------:|---------:|------:|--------:|
| UsingSynchronizedValue_ReadValue       | .NET 8.0             | 19.59 ns | 0.367 ns | 0.218 ns |  1.00 |    0.00 |
| UsingSynchronizedValue_ReadValue       | .NET Framework 4.6.2 | 26.41 ns | 0.737 ns | 0.488 ns |  1.34 |    0.02 |
|                                        |                      |          |          |          |       |         |
| UsingSynchronizedValue_WriteValue      | .NET 8.0             | 19.45 ns | 0.225 ns | 0.080 ns |  1.00 |    0.00 |
| UsingSynchronizedValue_WriteValue      | .NET Framework 4.6.2 | 27.10 ns | 0.443 ns | 0.197 ns |  1.39 |    0.01 |
|                                        |                      |          |          |          |       |         |
| UsingSynchronizedValue_ReadValueAsync  | .NET 8.0             | 23.83 ns | 0.674 ns | 0.353 ns |  1.00 |    0.00 |
| UsingSynchronizedValue_ReadValueAsync  | .NET Framework 4.6.2 | 31.26 ns | 0.669 ns | 0.442 ns |  1.31 |    0.01 |
|                                        |                      |          |          |          |       |         |
| UsingSynchronizedValue_WriteValueAsync | .NET 8.0             | 22.91 ns | 1.598 ns | 1.057 ns |  1.00 |    0.00 |
| UsingSynchronizedValue_WriteValueAsync | .NET Framework 4.6.2 | 29.72 ns | 0.572 ns | 0.254 ns |  1.33 |    0.04 |
