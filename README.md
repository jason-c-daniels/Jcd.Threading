# Jcd.Threading

A *netstandard2.0* library that provides utility classes to help simplify some
aspects of multi-threading and synchronization.

Read the [API documentation](./docs/Jcd.Threading.md) carefully.

## Features Provided

- [`TaskScheduler`](./docs/TaskSchedulerExtensions.md) extension `Run` to mimic the `Task.Run` API, ensuring tasks are
  run with the desired scheduler.
- [`IdleTaskScheduler`](./docs/IdleTaskScheduler.md), a custom task scheduler that schedules tasks in a round robin
  manner with idle threads.
- [`ThreadWrapper`](./docs/ThreadWrapper.md) class to simplify the process of making a pauseable thread.
- [`ItemProcessor<TItem>`](./docs/ItemProcessor_TItem_.md) class encapsulating a queue+worker thread.
- Various `Lock` extension methods to simplify using synchronization primitives (
  e.g. [SemaphoreSlimExtensions](./docs/SemaphoreSlimExtensions.md))
- Various synchronized value holder generics to automatically use and release a specific locking mechanism when getting
  or setting a value. (e.g. [ReaderWriterLockSlimValue](./docs/ReaderWriterLockSlimValue_T_.md))

## Examples

Execute `TaskSchedulerExtensions.Run` on a default instance of IdleTaskScheduler configured to provide 4 STA threads.

```csharp
using Jcd.Threading;
using Jcd.Threading.Tasks;

var its = new IdleTaskScheduler(4,ApartmentState.STA,"My Scheduler");
its.Run(()=>{/* do some work.*/});
```

Use `SemaphoreSlimExtensions.Lock` to automatically call `Wait` and `Release`

```csharp
using Jcd.Threading;

var sem = new SemaphoreSlim(1,1);
using (sem.Lock()) // This calls sem.Wait
{
   // This is your critical section. 
   // Do only what needs to be done
   // while the lock is held. Do everything 
   // else before or after.
}
// once .Dispose is called, sem.Release() is called.
```

Use `ReaderWriterLockSlimValue` to synchronize reads and writes to a single
shared value. Useful for needing exclusive write access for multiple readers
whose use case can tolerate slightly stale data, such as thread specific status
updates.

```csharp
using Jcd.Threading.SynchronizedValues;

const int initialValue=20;
var rwlsv = new ReaderWriterLockSlimValue<int>(initialValue);

// writer thread.
var wt = Task.Run(()=>{
   var sw = StopWatch.StartNew();
   int i=0;
   do
   {
      i++;
      rwlsv.Value = i;   // here we communicate thread-local information blocking all reads as its written.
      Thread.Sleep(100); // wait 0.1 seconds 
   }
   while(sw.ElapsedMilliseconds < 1000)
});

// reader thread 1.
var rt1 = Task.Run(()=>{
   var sw=StopWatch.StartNew();
   do
   {
      // here we read the data maintained by the writer thread, blocking writes as its read.
      Console.WriteLine($"[1] The count is: {rwlsv.Value}");
      Thread.Sleep(71); 
   }
   while(sw.ElapsedMilliseconds < 750)
});

// reader thread 2.
var rt1 = Task.Run(()=>{
   var sw=StopWatch.StartNew();
   do
   {
      // here we read the data maintained by the writer thread, blocking writes as its read.
      Console.WriteLine($"[2] The count is: {rwlsv.Value}");
      Thread.Sleep(50); 
   }
   while(sw.ElapsedMilliseconds < 1500)
});

// wait for all threads to finish.
await Task.WhenAll(new[]{wt,rt1,rt2});
```

These were just an overview of what's available. See [EXAMPLES.md](./EXAMPLES.md) for more and detailed examples.

And as always, read the [API documentation](./docs/Jcd.Threading.md)

## Badges

[![GitHub](https://img.shields.io/github/license/jason-c-daniels/Jcd.Threading)](https://github.com/jason-c-daniels/Jcd.Threading/blob/main/LICENSE)
[![Build status](https://ci.appveyor.com/api/projects/status/sbmfvmr1jmcf1pic?svg=true)](https://ci.appveyor.com/project/jason-c-daniels/jcd-threading)
[![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/jason-c-daniels/Jcd.Threading)](https://www.codefactor.io/repository/github/jason-c-daniels/Jcd.Threading)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=jason-c-daniels_Jcd.Threading&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=jason-c-daniels_Jcd.Threading)

[![MyGet](https://img.shields.io/myget/jason-c-daniels/v/Jcd.Threading?logo=nuget)](https://www.myget.org/feed/jason-c-daniels/package/nuget/Jcd.Threading)
[![Nuget](https://img.shields.io/nuget/v/Jcd.Threading?logo=nuget)](https://www.nuget.org/packages/Jcd.Threading)

[![API Docs](https://img.shields.io/badge/Read-The%20API%20Documentation-blue?style=for-the-badge)](https://github.com/jason-c-daniels/Jcd.Threading/blob/main/docs/Jcd.Threading.md)