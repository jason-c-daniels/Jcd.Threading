```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-YYFNSL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EBXDII : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```
| Method                                 | Runtime              | Mean      | Error    | StdDev   | Ratio | RatioSD |
|--------------------------------------- |--------------------- |----------:|---------:|---------:|------:|--------:|
| DirectCallsToTicket_ReadValue          | .NET 8.0             |  13.66 ns | 0.160 ns | 0.095 ns |  1.00 |    0.00 |
| DirectCallsToTicket_ReadValue          | .NET Framework 4.6.2 |  16.52 ns | 0.083 ns | 0.049 ns |  1.21 |    0.01 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToTicket_WriteValue         | .NET 8.0             |  14.02 ns | 0.122 ns | 0.064 ns |  1.00 |    0.00 |
| DirectCallsToTicket_WriteValue         | .NET Framework 4.6.2 |  16.48 ns | 0.078 ns | 0.041 ns |  1.18 |    0.01 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToTicket_ReadValueAsync     | .NET 8.0             |  27.60 ns | 0.508 ns | 0.336 ns |  1.00 |    0.00 |
| DirectCallsToTicket_ReadValueAsync     | .NET Framework 4.6.2 | 100.93 ns | 0.245 ns | 0.146 ns |  3.66 |    0.05 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToTicket_WriteValueAsync    | .NET 8.0             |  28.07 ns | 0.659 ns | 0.477 ns |  1.00 |    0.00 |
| DirectCallsToTicket_WriteValueAsync    | .NET Framework 4.6.2 | 101.05 ns | 0.436 ns | 0.228 ns |  3.61 |    0.07 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_ReadValue            | .NET 8.0             |  13.97 ns | 0.231 ns | 0.138 ns |  1.00 |    0.00 |
| DirectCallsToLock_ReadValue            | .NET Framework 4.6.2 |  16.32 ns | 0.124 ns | 0.065 ns |  1.17 |    0.01 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_WriteValue           | .NET 8.0             |  14.34 ns | 0.169 ns | 0.088 ns |  1.00 |    0.00 |
| DirectCallsToLock_WriteValue           | .NET Framework 4.6.2 |  16.40 ns | 0.087 ns | 0.052 ns |  1.14 |    0.01 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_ReadValueAsync       | .NET 8.0             |  33.26 ns | 0.974 ns | 0.704 ns |  1.00 |    0.00 |
| DirectCallsToLock_ReadValueAsync       | .NET Framework 4.6.2 | 147.30 ns | 7.815 ns | 5.169 ns |  4.43 |    0.14 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_WriteValueAsync      | .NET 8.0             |  35.19 ns | 1.027 ns | 0.743 ns |  1.00 |    0.00 |
| DirectCallsToLock_WriteValueAsync      | .NET Framework 4.6.2 | 150.23 ns | 4.030 ns | 2.914 ns |  4.27 |    0.12 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_ReadValue       | .NET 8.0             |  14.35 ns | 0.281 ns | 0.186 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_ReadValue       | .NET Framework 4.6.2 |  16.49 ns | 0.254 ns | 0.168 ns |  1.15 |    0.02 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_WriteValue      | .NET 8.0             |  14.69 ns | 0.106 ns | 0.055 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_WriteValue      | .NET Framework 4.6.2 |  17.85 ns | 1.255 ns | 0.907 ns |  1.23 |    0.07 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_ReadValueAsync  | .NET 8.0             |  32.63 ns | 0.476 ns | 0.283 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_ReadValueAsync  | .NET Framework 4.6.2 | 149.19 ns | 6.940 ns | 5.018 ns |  4.60 |    0.18 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_WriteValueAsync | .NET 8.0             |  34.16 ns | 0.252 ns | 0.132 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_WriteValueAsync | .NET Framework 4.6.2 | 147.90 ns | 3.617 ns | 2.615 ns |  4.33 |    0.09 |
