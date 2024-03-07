```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-SWTUPK : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-VBTVTX : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=10  MinIterationCount=5  WarmupCount=1  

```

| Method                                 | Runtime              |      Mean |     Error |    StdDev | Ratio | RatioSD |
|----------------------------------------|----------------------|----------:|----------:|----------:|------:|--------:|
| UsingMutexValue_ReadValue              | .NET 8.0             |  31.99 ns |  0.526 ns |  0.137 ns |  1.00 |    0.00 |
| UsingMutexValue_ReadValue              | .NET Framework 4.6.2 |  67.17 ns |  1.250 ns |  0.325 ns |  2.10 |    0.01 |
|                                        |                      |           |           |           |       |         |
| UsingMutexValue_WriteValue             | .NET 8.0             |  32.65 ns |  0.504 ns |  0.078 ns |  1.00 |    0.00 |
| UsingMutexValue_WriteValue             | .NET Framework 4.6.2 |  66.72 ns |  2.779 ns |  1.838 ns |  2.01 |    0.03 |
|                                        |                      |           |           |           |       |         |
| UsingSemaphoreDirectly_ReadValue       | .NET 8.0             |  30.71 ns |  0.574 ns |  0.149 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_ReadValue       | .NET Framework 4.6.2 |  65.82 ns |  1.113 ns |  0.494 ns |  2.14 |    0.01 |
|                                        |                      |           |           |           |       |         |
| UsingSemaphoreDirectly_WriteValue      | .NET 8.0             |  30.91 ns |  0.281 ns |  0.125 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_WriteValue      | .NET Framework 4.6.2 |  66.78 ns |  3.142 ns |  1.870 ns |  2.14 |    0.05 |
|                                        |                      |           |           |           |       |         |
| UsingSemaphoreDirectly_ReadValueAsync  | .NET 8.0             |  43.07 ns |  1.780 ns |  1.177 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_ReadValueAsync  | .NET Framework 4.6.2 |  96.47 ns |  4.376 ns |  2.895 ns |  2.24 |    0.05 |
|                                        |                      |           |           |           |       |         |
| UsingSemaphoreDirectly_WriteValueAsync | .NET 8.0             |  39.62 ns |  2.128 ns |  1.408 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_WriteValueAsync | .NET Framework 4.6.2 |  90.00 ns |  2.517 ns |  1.498 ns |  2.27 |    0.08 |
|                                        |                      |           |           |           |       |         |
| UsingExtensions_ReadValue              | .NET 8.0             |  35.70 ns |  1.452 ns |  0.864 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue              | .NET Framework 4.6.2 |  68.58 ns |  2.355 ns |  1.558 ns |  1.93 |    0.06 |
|                                        |                      |           |           |           |       |         |
| UsingExtensions_WriteValue             | .NET 8.0             |  34.15 ns |  0.711 ns |  0.185 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue             | .NET Framework 4.6.2 |  67.71 ns |  1.749 ns |  1.157 ns |  1.96 |    0.02 |
|                                        |                      |           |           |           |       |         |
| UsingExtensions_ReadValueAsync         | .NET 8.0             |  53.58 ns |  3.796 ns |  2.511 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValueAsync         | .NET Framework 4.6.2 | 130.06 ns |  2.199 ns |  0.571 ns |  2.46 |    0.15 |
|                                        |                      |           |           |           |       |         |
| UsingExtensions_WriteValueAsync        | .NET 8.0             |  50.13 ns |  1.630 ns |  1.078 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValueAsync        | .NET Framework 4.6.2 | 148.77 ns | 18.608 ns | 12.308 ns |  2.97 |    0.27 |
