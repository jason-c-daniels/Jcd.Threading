```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-SWTUPK : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-VBTVTX : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=10  MinIterationCount=5  WarmupCount=1  

```

| Method                                  | Runtime              |      Mean |     Error |   StdDev | Ratio | RatioSD |
|-----------------------------------------|----------------------|----------:|----------:|---------:|------:|--------:|
| UsingAsyncLock_Lock_ReadValue           | .NET 8.0             |  77.82 ns |  2.194 ns | 1.306 ns |  1.00 |    0.00 |
| UsingAsyncLock_Lock_ReadValue           | .NET Framework 4.6.2 | 219.44 ns |  7.393 ns | 4.890 ns |  2.84 |    0.07 |
|                                         |                      |           |           |          |       |         |
| UsingAsyncLock_Lock_WriteValue          | .NET 8.0             |  78.21 ns |  1.131 ns | 0.294 ns |  1.00 |    0.00 |
| UsingAsyncLock_Lock_WriteValue          | .NET Framework 4.6.2 | 200.99 ns |  5.215 ns | 3.103 ns |  2.58 |    0.05 |
|                                         |                      |           |           |          |       |         |
| UsingAsyncLock_LockAsync_ReadValue      | .NET 8.0             |  89.44 ns |  3.312 ns | 1.971 ns |  1.00 |    0.00 |
| UsingAsyncLock_LockAsync_ReadValue      | .NET Framework 4.6.2 | 274.00 ns |  6.671 ns | 4.412 ns |  3.07 |    0.09 |
|                                         |                      |           |           |          |       |         |
| UsingAsyncLock_LockAsync_WriteValue     | .NET 8.0             |  95.11 ns |  7.321 ns | 4.842 ns |  1.00 |    0.00 |
| UsingAsyncLock_LockAsync_WriteValue     | .NET Framework 4.6.2 | 277.90 ns | 16.639 ns | 9.901 ns |  2.90 |    0.18 |
|                                         |                      |           |           |          |       |         |
| UsingSemaphoreSlimExtensions_ReadValue  | .NET 8.0             |  93.58 ns |  6.536 ns | 4.323 ns |  1.00 |    0.00 |
| UsingSemaphoreSlimExtensions_ReadValue  | .NET Framework 4.6.2 | 284.83 ns | 13.305 ns | 7.918 ns |  3.05 |    0.14 |
|                                         |                      |           |           |          |       |         |
| UsingSemaphoreSlimExtensions_WriteValue | .NET 8.0             |  90.78 ns |  2.945 ns | 1.540 ns |  1.00 |    0.00 |
| UsingSemaphoreSlimExtensions_WriteValue | .NET Framework 4.6.2 | 277.00 ns |  6.731 ns | 4.005 ns |  3.05 |    0.07 |
