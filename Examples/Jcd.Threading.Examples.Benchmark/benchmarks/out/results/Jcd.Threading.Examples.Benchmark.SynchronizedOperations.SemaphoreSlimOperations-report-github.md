```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-YYFNSL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EBXDII : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```

| Method                                 | Runtime              |      Mean |     Error |   StdDev | Ratio | RatioSD |
|----------------------------------------|----------------------|----------:|----------:|---------:|------:|--------:|
| UsingMutexValue_ReadValue              | .NET 8.0             |  33.54 ns |  1.433 ns | 0.948 ns |  1.00 |    0.00 |
| UsingMutexValue_ReadValue              | .NET Framework 4.6.2 |  70.85 ns |  2.321 ns | 1.678 ns |  2.12 |    0.09 |
|                                        |                      |           |           |          |       |         |
| UsingMutexValue_WriteValue             | .NET 8.0             |  33.36 ns |  1.069 ns | 0.773 ns |  1.00 |    0.00 |
| UsingMutexValue_WriteValue             | .NET Framework 4.6.2 |  72.17 ns | 10.444 ns | 7.552 ns |  2.17 |    0.25 |
|                                        |                      |           |           |          |       |         |
| UsingSemaphoreDirectly_ReadValue       | .NET 8.0             |  32.47 ns |  0.941 ns | 0.680 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_ReadValue       | .NET Framework 4.6.2 |  64.87 ns |  1.267 ns | 0.663 ns |  1.99 |    0.05 |
|                                        |                      |           |           |          |       |         |
| UsingSemaphoreDirectly_WriteValue      | .NET 8.0             |  31.62 ns |  0.622 ns | 0.370 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_WriteValue      | .NET Framework 4.6.2 |  67.25 ns |  2.476 ns | 1.791 ns |  2.14 |    0.05 |
|                                        |                      |           |           |          |       |         |
| UsingSemaphoreDirectly_ReadValueAsync  | .NET 8.0             |  39.22 ns |  0.670 ns | 0.298 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_ReadValueAsync  | .NET Framework 4.6.2 |  90.58 ns |  2.946 ns | 2.130 ns |  2.33 |    0.06 |
|                                        |                      |           |           |          |       |         |
| UsingSemaphoreDirectly_WriteValueAsync | .NET 8.0             |  42.55 ns |  6.202 ns | 4.484 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_WriteValueAsync | .NET Framework 4.6.2 |  89.59 ns |  1.597 ns | 1.155 ns |  2.12 |    0.20 |
|                                        |                      |           |           |          |       |         |
| UsingExtensions_ReadValue              | .NET 8.0             |  36.49 ns |  0.559 ns | 0.333 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue              | .NET Framework 4.6.2 |  71.80 ns |  1.351 ns | 0.977 ns |  1.96 |    0.04 |
|                                        |                      |           |           |          |       |         |
| UsingExtensions_WriteValue             | .NET 8.0             |  38.31 ns |  1.160 ns | 0.768 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue             | .NET Framework 4.6.2 |  75.68 ns |  2.332 ns | 1.542 ns |  1.98 |    0.06 |
|                                        |                      |           |           |          |       |         |
| UsingExtensions_ReadValueAsync         | .NET 8.0             |  58.79 ns |  5.279 ns | 3.817 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValueAsync         | .NET Framework 4.6.2 | 183.99 ns |  5.968 ns | 3.947 ns |  3.14 |    0.25 |
|                                        |                      |           |           |          |       |         |
| UsingExtensions_WriteValueAsync        | .NET 8.0             |  55.64 ns |  2.492 ns | 1.649 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValueAsync        | .NET Framework 4.6.2 | 184.04 ns |  8.249 ns | 5.964 ns |  3.31 |    0.09 |
