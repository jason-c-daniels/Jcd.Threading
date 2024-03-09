```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EDIIFL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-DEBPPF : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```

| Method                                 | Runtime              |     Mean |    Error |   StdDev | Ratio | RatioSD |
|----------------------------------------|----------------------|---------:|---------:|---------:|------:|--------:|
| UsingSynchronizedValue_ReadValue       | .NET 8.0             | 18.79 ns | 0.366 ns | 0.242 ns |  1.00 |    0.00 |
| UsingSynchronizedValue_ReadValue       | .NET Framework 4.6.2 | 25.00 ns | 0.152 ns | 0.090 ns |  1.33 |    0.02 |
|                                        |                      |          |          |          |       |         |
| UsingSynchronizedValue_WriteValue      | .NET 8.0             | 19.91 ns | 0.271 ns | 0.142 ns |  1.00 |    0.00 |
| UsingSynchronizedValue_WriteValue      | .NET Framework 4.6.2 | 25.57 ns | 0.336 ns | 0.200 ns |  1.28 |    0.01 |
|                                        |                      |          |          |          |       |         |
| UsingSynchronizedValue_ReadValueAsync  | .NET 8.0             | 24.58 ns | 0.799 ns | 0.529 ns |  1.00 |    0.00 |
| UsingSynchronizedValue_ReadValueAsync  | .NET Framework 4.6.2 | 28.38 ns | 0.333 ns | 0.198 ns |  1.15 |    0.03 |
|                                        |                      |          |          |          |       |         |
| UsingSynchronizedValue_WriteValueAsync | .NET 8.0             | 21.39 ns | 0.439 ns | 0.318 ns |  1.00 |    0.00 |
| UsingSynchronizedValue_WriteValueAsync | .NET Framework 4.6.2 | 28.32 ns | 0.849 ns | 0.614 ns |  1.32 |    0.04 |
