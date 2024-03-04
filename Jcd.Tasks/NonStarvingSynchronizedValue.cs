using System;
using System.Threading;

namespace Jcd.Tasks;

public class NonStarvingSynchronizedValue<T> : IDisposable
{
   int readerCount; // init to 0; number of readers currently accessing resource

   private T data;

   public NonStarvingSynchronizedValue(T initialValue) { data = initialValue; }

   // all semaphores initialised to 1
   SemaphoreSlim resourceMutex        = new(1, 1); // controls access (read/write) to the resource. Binary semaphore.
   SemaphoreSlim orderPreservingMutex = new(1, 1); // FAIRNESS: preserves ordering of requests (signaling must be FIFO)

   public T Value
   {
      get => GetValue();
      set => SetValue(value);
   }

   public T GetValue()
   {
      try
      {
         BeginRead();

         return data;
      }
      finally
      {
         EndRead();
      }
   }

   private void EndRead()
   {
      var result = Interlocked.Decrement(ref readerCount);
      if (result == 0)            // if there are no readers left
         resourceMutex.Release(); // release resource access for all
   }

   private void BeginRead()
   {
      try
      {
         orderPreservingMutex.Wait();

         // increment in an atomic operation.
         var result = Interlocked.Increment(ref readerCount);
         if (result == 1)         // if I am the first reader
            resourceMutex.Wait(); // request resource access for readers (writers blocked)
      }                           // let next in line be serviced
      finally
      {
         orderPreservingMutex.Release();
      }
   }

   public void SetValue(T value)
   {
      using (orderPreservingMutex.Lock()) // wait in line to be serviced
         resourceMutex.Wait();            // request exclusive access to resource (readers and other writers blocked)

      data = value;
      resourceMutex.Release(); // release resource access for next reader/writer
   }

   public void Dispose()
   {
      resourceMutex.Dispose();
      orderPreservingMutex.Dispose();
   }
}