```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EDIIFL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-DEBPPF : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```

| Method                                 | Runtime              |      Mean |    Error |   StdDev | Ratio | RatioSD |
|----------------------------------------|----------------------|----------:|---------:|---------:|------:|--------:|
| UsingMutexValue_ReadValue              | .NET 8.0             |  32.60 ns | 0.817 ns | 0.591 ns |  1.00 |    0.00 |
| UsingMutexValue_ReadValue              | .NET Framework 4.6.2 |  66.14 ns | 1.790 ns | 1.184 ns |  2.03 |    0.06 |
|                                        |                      |           |          |          |       |         |
| UsingMutexValue_WriteValue             | .NET 8.0             |  32.94 ns | 0.895 ns | 0.647 ns |  1.00 |    0.00 |
| UsingMutexValue_WriteValue             | .NET Framework 4.6.2 |  65.87 ns | 1.138 ns | 0.677 ns |  2.00 |    0.04 |
|                                        |                      |           |          |          |       |         |
| UsingSemaphoreDirectly_ReadValue       | .NET 8.0             |  33.41 ns | 0.997 ns | 0.721 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_ReadValue       | .NET Framework 4.6.2 |  67.55 ns | 1.112 ns | 0.494 ns |  2.04 |    0.05 |
|                                        |                      |           |          |          |       |         |
| UsingSemaphoreDirectly_WriteValue      | .NET 8.0             |  32.56 ns | 0.929 ns | 0.553 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_WriteValue      | .NET Framework 4.6.2 |  65.05 ns | 1.401 ns | 1.013 ns |  2.00 |    0.03 |
|                                        |                      |           |          |          |       |         |
| UsingSemaphoreDirectly_ReadValueAsync  | .NET 8.0             |  39.13 ns | 2.139 ns | 1.273 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_ReadValueAsync  | .NET Framework 4.6.2 |  89.01 ns | 2.939 ns | 2.125 ns |  2.27 |    0.09 |
|                                        |                      |           |          |          |       |         |
| UsingSemaphoreDirectly_WriteValueAsync | .NET 8.0             |  39.92 ns | 2.390 ns | 1.422 ns |  1.00 |    0.00 |
| UsingSemaphoreDirectly_WriteValueAsync | .NET Framework 4.6.2 |  91.01 ns | 4.506 ns | 3.258 ns |  2.30 |    0.06 |
|                                        |                      |           |          |          |       |         |
| UsingExtensions_ReadValue              | .NET 8.0             |  36.90 ns | 1.988 ns | 1.437 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValue              | .NET Framework 4.6.2 |  71.43 ns | 3.108 ns | 2.247 ns |  1.94 |    0.11 |
|                                        |                      |           |          |          |       |         |
| UsingExtensions_WriteValue             | .NET 8.0             |  36.66 ns | 0.713 ns | 0.424 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValue             | .NET Framework 4.6.2 |  71.31 ns | 2.076 ns | 1.501 ns |  1.93 |    0.04 |
|                                        |                      |           |          |          |       |         |
| UsingExtensions_ReadValueAsync         | .NET 8.0             |  58.51 ns | 5.833 ns | 4.218 ns |  1.00 |    0.00 |
| UsingExtensions_ReadValueAsync         | .NET Framework 4.6.2 | 177.58 ns | 3.025 ns | 1.800 ns |  3.11 |    0.19 |
|                                        |                      |           |          |          |       |         |
| UsingExtensions_WriteValueAsync        | .NET 8.0             |  57.30 ns | 3.542 ns | 2.561 ns |  1.00 |    0.00 |
| UsingExtensions_WriteValueAsync        | .NET Framework 4.6.2 | 176.99 ns | 2.724 ns | 1.621 ns |  3.12 |    0.15 |
