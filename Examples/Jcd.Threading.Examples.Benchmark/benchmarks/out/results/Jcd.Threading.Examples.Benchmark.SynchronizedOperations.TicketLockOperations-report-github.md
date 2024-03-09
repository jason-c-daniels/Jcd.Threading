```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.102
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EDIIFL : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-DEBPPF : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256

MaxIterationCount=11  MinIterationCount=9  WarmupCount=1  

```
| Method                                 | Runtime              | Mean      | Error    | StdDev   | Ratio | RatioSD |
|--------------------------------------- |--------------------- |----------:|---------:|---------:|------:|--------:|
| DirectCallsToTicket_ReadValue          | .NET 8.0             |  13.94 ns | 0.531 ns | 0.384 ns |  1.00 |    0.00 |
| DirectCallsToTicket_ReadValue          | .NET Framework 4.6.2 |  17.28 ns | 1.549 ns | 1.120 ns |  1.24 |    0.09 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToTicket_WriteValue         | .NET 8.0             |  21.07 ns | 3.489 ns | 2.523 ns |  1.00 |    0.00 |
| DirectCallsToTicket_WriteValue         | .NET Framework 4.6.2 |  16.72 ns | 0.430 ns | 0.284 ns |  0.79 |    0.08 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToTicket_ReadValueAsync     | .NET 8.0             |  28.26 ns | 1.280 ns | 0.762 ns |  1.00 |    0.00 |
| DirectCallsToTicket_ReadValueAsync     | .NET Framework 4.6.2 | 103.67 ns | 3.688 ns | 2.439 ns |  3.68 |    0.15 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToTicket_WriteValueAsync    | .NET 8.0             |  26.55 ns | 1.174 ns | 0.849 ns |  1.00 |    0.00 |
| DirectCallsToTicket_WriteValueAsync    | .NET Framework 4.6.2 | 103.30 ns | 3.129 ns | 2.262 ns |  3.90 |    0.17 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_ReadValue            | .NET 8.0             |  14.00 ns | 0.393 ns | 0.284 ns |  1.00 |    0.00 |
| DirectCallsToLock_ReadValue            | .NET Framework 4.6.2 |  16.17 ns | 0.527 ns | 0.349 ns |  1.15 |    0.04 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_WriteValue           | .NET 8.0             |  14.49 ns | 0.487 ns | 0.352 ns |  1.00 |    0.00 |
| DirectCallsToLock_WriteValue           | .NET Framework 4.6.2 |  16.94 ns | 0.330 ns | 0.196 ns |  1.17 |    0.03 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_ReadValueAsync       | .NET 8.0             |  34.55 ns | 1.064 ns | 0.704 ns |  1.00 |    0.00 |
| DirectCallsToLock_ReadValueAsync       | .NET Framework 4.6.2 | 143.07 ns | 2.203 ns | 1.152 ns |  4.13 |    0.09 |
|                                        |                      |           |          |          |       |         |
| DirectCallsToLock_WriteValueAsync      | .NET 8.0             |  34.37 ns | 1.293 ns | 0.935 ns |  1.00 |    0.00 |
| DirectCallsToLock_WriteValueAsync      | .NET Framework 4.6.2 | 142.03 ns | 1.723 ns | 0.765 ns |  4.12 |    0.11 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_ReadValue       | .NET 8.0             |  15.44 ns | 1.968 ns | 1.423 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_ReadValue       | .NET Framework 4.6.2 |  16.92 ns | 0.514 ns | 0.372 ns |  1.10 |    0.10 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_WriteValue      | .NET 8.0             |  14.54 ns | 0.293 ns | 0.174 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_WriteValue      | .NET Framework 4.6.2 |  17.14 ns | 0.472 ns | 0.341 ns |  1.18 |    0.03 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_ReadValueAsync  | .NET 8.0             |  32.64 ns | 1.010 ns | 0.668 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_ReadValueAsync  | .NET Framework 4.6.2 | 142.65 ns | 2.935 ns | 1.942 ns |  4.37 |    0.12 |
|                                        |                      |           |          |          |       |         |
| UsingTicketLockedValue_WriteValueAsync | .NET 8.0             |  33.49 ns | 0.801 ns | 0.530 ns |  1.00 |    0.00 |
| UsingTicketLockedValue_WriteValueAsync | .NET Framework 4.6.2 | 141.34 ns | 1.305 ns | 0.682 ns |  4.22 |    0.08 |
