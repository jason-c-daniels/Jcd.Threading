```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-TMZHUX : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-AAPCYZ : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```
| Method                                 | Runtime              | Mean      | Error    | StdDev   | Ratio | RatioSD |
|--------------------------------------- |--------------------- |----------:|---------:|---------:|------:|--------:|
| DirectCallsToTicket_ReadValue          | .NET 8.0             |  13.71 ns | 0.368 ns | 0.266 ns |  1.00 |    0.00 |
| DirectCallsToTicket_ReadValue          | .NET Framework 4.6.2 |  17.83 ns | 1.090 ns | 0.788 ns |  1.30 |    0.07 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToTicket_WriteValue         | .NET 8.0             |  14.68 ns | 0.811 ns | 0.586 ns |  1.00 |    0.00 |
| DirectCallsToTicket_WriteValue         | .NET Framework 4.6.2 |  17.18 ns | 0.795 ns | 0.575 ns |  1.17 |    0.05 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToTicket_ReadValueAsync     | .NET 8.0             |  26.21 ns | 0.380 ns | 0.226 ns |  1.00 |    0.00 |
| DirectCallsToTicket_ReadValueAsync     | .NET Framework 4.6.2 | 105.96 ns | 2.087 ns | 1.380 ns |  4.05 |    0.08 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToTicket_WriteValueAsync    | .NET 8.0             |  27.00 ns | 0.943 ns | 0.682 ns |  1.00 |    0.00 |
| DirectCallsToTicket_WriteValueAsync    | .NET Framework 4.6.2 | 105.26 ns | 3.674 ns | 2.657 ns |  3.90 |    0.16 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_ReadValue            | .NET 8.0             |  13.68 ns | 0.323 ns | 0.192 ns |  1.00 |    0.00 |
| DirectCallsToLock_ReadValue            | .NET Framework 4.6.2 |  17.37 ns | 0.281 ns | 0.147 ns |  1.27 |    0.02 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_WriteValue           | .NET 8.0             |  14.69 ns | 1.260 ns | 0.911 ns |  1.00 |    0.00 |
| DirectCallsToLock_WriteValue           | .NET Framework 4.6.2 |  16.62 ns | 0.149 ns | 0.078 ns |  1.13 |    0.07 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_ReadValueAsync       | .NET 8.0             |  33.32 ns | 1.965 ns | 1.421 ns |  1.00 |    0.00 |
| DirectCallsToLock_ReadValueAsync       | .NET Framework 4.6.2 | 143.45 ns | 1.909 ns | 0.998 ns |  4.39 |    0.13 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_WriteValueAsync      | .NET 8.0             |  36.69 ns | 2.014 ns | 1.456 ns |  1.00 |    0.00 |
| DirectCallsToLock_WriteValueAsync      | .NET Framework 4.6.2 | 141.77 ns | 0.795 ns | 0.416 ns |  3.87 |    0.18 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_ReadValue       | .NET 8.0             |  14.74 ns | 0.868 ns | 0.628 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_ReadValue       | .NET Framework 4.6.2 |  16.58 ns | 0.285 ns | 0.149 ns |  1.11 |    0.04 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_WriteValue      | .NET 8.0             |  14.68 ns | 0.211 ns | 0.094 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_WriteValue      | .NET Framework 4.6.2 |  17.17 ns | 0.221 ns | 0.131 ns |  1.17 |    0.01 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_ReadValueAsync  | .NET 8.0             |  32.68 ns | 0.979 ns | 0.708 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_ReadValueAsync  | .NET Framework 4.6.2 | 142.44 ns | 2.094 ns | 1.246 ns |  4.40 |    0.06 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_WriteValueAsync | .NET 8.0             |  35.07 ns | 1.366 ns | 0.813 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_WriteValueAsync | .NET Framework 4.6.2 | 147.38 ns | 3.714 ns | 2.210 ns |  4.21 |    0.14 |
