```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-SWTUPK : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-VBTVTX : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=10  MinIterationCount=5  WarmupCount=1  

```
| Method                                 | Runtime              | Mean      | Error    | StdDev   | Ratio | RatioSD |
|--------------------------------------- |--------------------- |----------:|---------:|---------:|------:|--------:|
| DirectCallsToTicket_ReadValue          | .NET 8.0             |  13.36 ns | 0.111 ns | 0.017 ns |  1.00 |    0.00 |
| DirectCallsToTicket_ReadValue          | .NET Framework 4.6.2 |  15.68 ns | 0.279 ns | 0.124 ns |  1.17 |    0.01 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToTicket_WriteValue         | .NET 8.0             |  13.49 ns | 0.242 ns | 0.063 ns |  1.00 |    0.00 |
| DirectCallsToTicket_WriteValue         | .NET Framework 4.6.2 |  15.93 ns | 0.257 ns | 0.114 ns |  1.18 |    0.01 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToTicket_ReadValueAsync     | .NET 8.0             |  29.00 ns | 0.429 ns | 0.255 ns |  1.00 |    0.00 |
| DirectCallsToTicket_ReadValueAsync     | .NET Framework 4.6.2 |  94.64 ns | 1.699 ns | 0.888 ns |  3.26 |    0.04 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToTicket_WriteValueAsync    | .NET 8.0             |  28.22 ns | 0.575 ns | 0.342 ns |  1.00 |    0.00 |
| DirectCallsToTicket_WriteValueAsync    | .NET Framework 4.6.2 |  94.93 ns | 1.708 ns | 1.017 ns |  3.36 |    0.05 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_ReadValue            | .NET 8.0             |  13.31 ns | 0.243 ns | 0.087 ns |  1.00 |    0.00 |
| DirectCallsToLock_ReadValue            | .NET Framework 4.6.2 |  15.47 ns | 0.290 ns | 0.152 ns |  1.16 |    0.01 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_WriteValue           | .NET 8.0             |  13.59 ns | 0.224 ns | 0.058 ns |  1.00 |    0.00 |
| DirectCallsToLock_WriteValue           | .NET Framework 4.6.2 |  15.95 ns | 0.152 ns | 0.024 ns |  1.18 |    0.00 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_ReadValueAsync       | .NET 8.0             |  37.83 ns | 0.842 ns | 0.557 ns |  1.00 |    0.00 |
| DirectCallsToLock_ReadValueAsync       | .NET Framework 4.6.2 | 140.10 ns | 2.124 ns | 0.552 ns |  3.69 |    0.05 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_WriteValueAsync      | .NET 8.0             |  37.51 ns | 1.260 ns | 0.834 ns |  1.00 |    0.00 |
| DirectCallsToLock_WriteValueAsync      | .NET Framework 4.6.2 | 140.77 ns | 2.098 ns | 0.748 ns |  3.76 |    0.06 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_ReadValue       | .NET 8.0             |  13.23 ns | 0.219 ns | 0.057 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_ReadValue       | .NET Framework 4.6.2 |  16.38 ns | 0.288 ns | 0.103 ns |  1.24 |    0.01 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_WriteValue      | .NET 8.0             |  14.37 ns | 0.282 ns | 0.148 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_WriteValue      | .NET Framework 4.6.2 |  17.03 ns | 0.264 ns | 0.068 ns |  1.19 |    0.02 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_ReadValueAsync  | .NET 8.0             |  36.50 ns | 1.010 ns | 0.601 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_ReadValueAsync  | .NET Framework 4.6.2 | 140.51 ns | 2.346 ns | 0.836 ns |  3.85 |    0.07 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_WriteValueAsync | .NET 8.0             |  37.31 ns | 0.930 ns | 0.615 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_WriteValueAsync | .NET Framework 4.6.2 | 139.13 ns | 2.548 ns | 0.909 ns |  3.72 |    0.08 |
