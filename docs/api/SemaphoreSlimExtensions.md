#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## SemaphoreSlimExtensions Class

Provides extension methods to simplify using a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')  
to ensure the correct pairing of calls to of Enter and Exit.

```csharp
public static class SemaphoreSlimExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SemaphoreSlimExtensions

### Remarks
  
These methods are intended to be used with a using block as illustrated below.   
This will ensure the lock is held for no more time than necessary.  
  
Contrast this with a using declaration where an method may grow in length over time,  
and and execution time. Usually most of the lines in those methods shouldn't hold  
the lock. The reason is the longer a lock is held, the more contention there will be.  
And large scale contention for resources adversely impacts performance application  
performance.  
  
```csharp  
// problem illustration:  
void DoNotDoThis()  
{  
   using _ = sem.Lock();                     // acquire the lock. But don't use the value. Just dispose it.  
   AShortActionRequiringSynchronization();   // very fast: done in 10 microseconds.  
   AShortActionRequiringSynchronization();   // fast: done in 75 microseconds.  
   AShortActionRequiringNoSynchronization(); // reasonable but unwanted: done in 5 milliseconds.  
   ALongActionRequiringNoSynchronization();  // slow: done in 500 milliseconds.      
} // the lock is disposed (and released) here.  
```  
  
The reason the above code is problematic is the lock is held until disposal.   
The result of Lock is an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') bound to the [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')  
which exits the lock when `Dispose` is called. `Dispose` won't be called until  
the method is exited, which is the very nature of a using declaration.  
  
Instead, use a traditional using block. Below is the corrected code.  
  
  
```csharp  
// problem resolution:  
void DefinitelyDoThis()  
{  
   using (sem.Lock())                           // acquire the lock. But don't use the value.  
   {   
      AShortActionRequiringSynchronization();   // very fast: done in 10 microseconds.  
      AShortActionRequiringSynchronization();   // fast: done in 75 microseconds.  
   }   
   AShortActionRequiringNoSynchronization();    // the lock is no longer held. This won't cause contention.  
   ALongActionRequiringNoSynchronization();     // the lock is no longer held. This won't cause contention.  
}  
```  
  
As you can see, a using block clearly describes the scope for which  
the lock needs to be held.

| Methods | |
| :--- | :--- |
| [GetResourceLock(this SemaphoreSlim)](SemaphoreSlimExtensions.GetResourceLock.h1dPX+eVPpUTRJ1Gj72Y6Q.md 'Jcd.Threading.SemaphoreSlimExtensions.GetResourceLock(this System.Threading.SemaphoreSlim)') | Gets a resource lock bound to the instance of a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') |
| [Lock(this SemaphoreSlim, CancellationToken)](SemaphoreSlimExtensions.Lock.lrzWlWBiCw9Z+BhVijNMVw.md 'Jcd.Threading.SemaphoreSlimExtensions.Lock(this System.Threading.SemaphoreSlim, System.Threading.CancellationToken)') | Waits on the semaphore, and returns an [SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock') that calls Release. |
| [Lock(this SemaphoreSlim)](SemaphoreSlimExtensions.Lock.TfibVEOq4/VaWrHC7tH/rg.md 'Jcd.Threading.SemaphoreSlimExtensions.Lock(this System.Threading.SemaphoreSlim)') | Waits on the semaphore, and returns an [SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock') that calls Release. |
| [LockAsync(this SemaphoreSlim, CancellationToken)](SemaphoreSlimExtensions.LockAsync.w5Z5NNlB0OW05M7hDmlT0w.md 'Jcd.Threading.SemaphoreSlimExtensions.LockAsync(this System.Threading.SemaphoreSlim, System.Threading.CancellationToken)') | Asynchronously waits on the semaphore, and returns an [SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock') that calls Release. |
| [LockAsync(this SemaphoreSlim)](SemaphoreSlimExtensions.LockAsync.thM6pz8QjtVLgPqK6jAgIA.md 'Jcd.Threading.SemaphoreSlimExtensions.LockAsync(this System.Threading.SemaphoreSlim)') | Asynchronously waits on the semaphore, and returns an [SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock') that calls Release. |
