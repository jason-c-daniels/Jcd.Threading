```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EDIIFL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-DEBPPF : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```

| Method                                  | Runtime              |      Mean |     Error |   StdDev | Ratio | RatioSD |
|-----------------------------------------|----------------------|----------:|----------:|---------:|------:|--------:|
| UsingAsyncLock_Lock_ReadValue           | .NET 8.0             |  82.06 ns |  4.950 ns | 3.579 ns |  1.00 |    0.00 |
| UsingAsyncLock_Lock_ReadValue           | .NET Framework 4.6.2 | 207.17 ns |  4.407 ns | 3.186 ns |  2.53 |    0.12 |
|                                         |                      |           |           |          |       |         |
| UsingAsyncLock_Lock_WriteValue          | .NET 8.0             |  79.14 ns |  2.304 ns | 1.666 ns |  1.00 |    0.00 |
| UsingAsyncLock_Lock_WriteValue          | .NET Framework 4.6.2 | 210.42 ns |  5.107 ns | 3.692 ns |  2.66 |    0.08 |
|                                         |                      |           |           |          |       |         |
| UsingAsyncLock_LockAsync_ReadValue      | .NET 8.0             |  86.35 ns |  1.970 ns | 1.424 ns |  1.00 |    0.00 |
| UsingAsyncLock_LockAsync_ReadValue      | .NET Framework 4.6.2 | 272.83 ns |  6.778 ns | 4.901 ns |  3.16 |    0.06 |
|                                         |                      |           |           |          |       |         |
| UsingAsyncLock_LockAsync_WriteValue     | .NET 8.0             |  86.30 ns |  1.727 ns | 0.767 ns |  1.00 |    0.00 |
| UsingAsyncLock_LockAsync_WriteValue     | .NET Framework 4.6.2 | 269.70 ns |  7.891 ns | 5.705 ns |  3.15 |    0.08 |
|                                         |                      |           |           |          |       |         |
| UsingSemaphoreSlimExtensions_ReadValue  | .NET 8.0             |  87.48 ns |  2.495 ns | 1.804 ns |  1.00 |    0.00 |
| UsingSemaphoreSlimExtensions_ReadValue  | .NET Framework 4.6.2 | 271.64 ns |  7.765 ns | 5.614 ns |  3.11 |    0.09 |
|                                         |                      |           |           |          |       |         |
| UsingSemaphoreSlimExtensions_WriteValue | .NET 8.0             |  87.43 ns |  2.175 ns | 1.439 ns |  1.00 |    0.00 |
| UsingSemaphoreSlimExtensions_WriteValue | .NET Framework 4.6.2 | 264.27 ns | 11.991 ns | 8.670 ns |  3.01 |    0.12 |
