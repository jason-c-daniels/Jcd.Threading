```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-TMZHUX : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-AAPCYZ : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```
| Method                                  | Runtime              | Mean      | Error     | StdDev    | Ratio | RatioSD |
|---------------------------------------- |--------------------- |----------:|----------:|----------:|------:|--------:|
| UsingAsyncLock_Lock_ReadValue           | .NET 8.0             |  77.06 ns |  1.500 ns |  0.893 ns |  1.00 |    0.00 |
| UsingAsyncLock_Lock_ReadValue           | .NET Framework 4.6.2 | 211.15 ns |  2.055 ns |  1.223 ns |  2.74 |    0.03 |
|                                         |                      |           |           |           |       |         |
| UsingAsyncLock_Lock_WriteValue          | .NET 8.0             |  80.25 ns |  2.804 ns |  2.027 ns |  1.00 |    0.00 |
| UsingAsyncLock_Lock_WriteValue          | .NET Framework 4.6.2 | 205.22 ns |  2.170 ns |  1.291 ns |  2.58 |    0.05 |
|                                         |                      |           |           |           |       |         |
| UsingAsyncLock_LockAsync_ReadValue      | .NET 8.0             |  87.75 ns |  2.873 ns |  1.901 ns |  1.00 |    0.00 |
| UsingAsyncLock_LockAsync_ReadValue      | .NET Framework 4.6.2 | 258.46 ns |  3.695 ns |  2.199 ns |  2.94 |    0.06 |
|                                         |                      |           |           |           |       |         |
| UsingAsyncLock_LockAsync_WriteValue     | .NET 8.0             |  84.95 ns |  1.716 ns |  1.240 ns |  1.00 |    0.00 |
| UsingAsyncLock_LockAsync_WriteValue     | .NET Framework 4.6.2 | 262.69 ns |  5.148 ns |  3.063 ns |  3.09 |    0.04 |
|                                         |                      |           |           |           |       |         |
| UsingSemaphoreSlimExtensions_ReadValue  | .NET 8.0             |  85.57 ns |  0.939 ns |  0.491 ns |  1.00 |    0.00 |
| UsingSemaphoreSlimExtensions_ReadValue  | .NET Framework 4.6.2 | 294.11 ns | 17.106 ns | 11.315 ns |  3.43 |    0.13 |
|                                         |                      |           |           |           |       |         |
| UsingSemaphoreSlimExtensions_WriteValue | .NET 8.0             |  86.71 ns |  0.933 ns |  0.488 ns |  1.00 |    0.00 |
| UsingSemaphoreSlimExtensions_WriteValue | .NET Framework 4.6.2 | 260.40 ns |  3.554 ns |  2.115 ns |  3.01 |    0.04 |
