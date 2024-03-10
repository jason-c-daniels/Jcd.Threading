```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-YYFNSL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EBXDII : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```

| Method                                  | Runtime              |      Mean |     Error |   StdDev | Ratio | RatioSD |
|-----------------------------------------|----------------------|----------:|----------:|---------:|------:|--------:|
| UsingAsyncLock_Lock_ReadValue           | .NET 8.0             |  80.60 ns |  2.699 ns | 1.952 ns |  1.00 |    0.00 |
| UsingAsyncLock_Lock_ReadValue           | .NET Framework 4.6.2 | 217.09 ns |  7.163 ns | 5.179 ns |  2.70 |    0.11 |
|                                         |                      |           |           |          |       |         |
| UsingAsyncLock_Lock_WriteValue          | .NET 8.0             |  79.57 ns |  4.843 ns | 2.882 ns |  1.00 |    0.00 |
| UsingAsyncLock_Lock_WriteValue          | .NET Framework 4.6.2 | 215.68 ns |  4.927 ns | 3.259 ns |  2.72 |    0.09 |
|                                         |                      |           |           |          |       |         |
| UsingAsyncLock_LockAsync_ReadValue      | .NET 8.0             |  86.38 ns |  1.650 ns | 0.982 ns |  1.00 |    0.00 |
| UsingAsyncLock_LockAsync_ReadValue      | .NET Framework 4.6.2 | 267.89 ns |  8.682 ns | 5.743 ns |  3.11 |    0.09 |
|                                         |                      |           |           |          |       |         |
| UsingAsyncLock_LockAsync_WriteValue     | .NET 8.0             |  92.79 ns |  5.325 ns | 3.850 ns |  1.00 |    0.00 |
| UsingAsyncLock_LockAsync_WriteValue     | .NET Framework 4.6.2 | 274.49 ns |  9.320 ns | 6.739 ns |  2.96 |    0.16 |
|                                         |                      |           |           |          |       |         |
| UsingSemaphoreSlimExtensions_ReadValue  | .NET 8.0             |  91.83 ns |  4.981 ns | 3.295 ns |  1.00 |    0.00 |
| UsingSemaphoreSlimExtensions_ReadValue  | .NET Framework 4.6.2 | 275.93 ns | 11.034 ns | 7.978 ns |  3.01 |    0.13 |
|                                         |                      |           |           |          |       |         |
| UsingSemaphoreSlimExtensions_WriteValue | .NET 8.0             |  94.61 ns |  6.730 ns | 4.866 ns |  1.00 |    0.00 |
| UsingSemaphoreSlimExtensions_WriteValue | .NET Framework 4.6.2 | 266.14 ns | 10.752 ns | 7.775 ns |  2.82 |    0.20 |
