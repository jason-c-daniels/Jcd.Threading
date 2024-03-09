```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-TMZHUX : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-AAPCYZ : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```
| Method                                 | Runtime              | Mean     | Error    | StdDev   | Ratio |
|--------------------------------------- |--------------------- |---------:|---------:|---------:|------:|
| UsingSynchronizedValue_ReadValue       | .NET 8.0             | 19.36 ns | 0.045 ns | 0.027 ns |  1.00 |
| UsingSynchronizedValue_ReadValue       | .NET Framework 4.6.2 | 24.65 ns | 0.226 ns | 0.135 ns |  1.27 |
|                                        |                      |          |          |          |       |
| UsingSynchronizedValue_WriteValue      | .NET 8.0             | 19.48 ns | 0.218 ns | 0.114 ns |  1.00 |
| UsingSynchronizedValue_WriteValue      | .NET Framework 4.6.2 | 25.22 ns | 0.415 ns | 0.217 ns |  1.29 |
|                                        |                      |          |          |          |       |
| UsingSynchronizedValue_ReadValueAsync  | .NET 8.0             | 23.43 ns | 0.151 ns | 0.079 ns |  1.00 |
| UsingSynchronizedValue_ReadValueAsync  | .NET Framework 4.6.2 | 28.37 ns | 0.383 ns | 0.170 ns |  1.21 |
|                                        |                      |          |          |          |       |
| UsingSynchronizedValue_WriteValueAsync | .NET 8.0             | 21.27 ns | 0.196 ns | 0.103 ns |  1.00 |
| UsingSynchronizedValue_WriteValueAsync | .NET Framework 4.6.2 | 28.29 ns | 0.257 ns | 0.134 ns |  1.33 |
