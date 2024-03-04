using System.Runtime.CompilerServices;
using System.Threading;
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8601 // Possible null reference assignment.

namespace Jcd.Tasks;

/// <summary>
/// Provides synchronization to an underlying value through a <see cref="SpinLock"/>.
/// </summary>
/// <typeparam name="T">The type of the data being stored.</typeparam>
internal class SpinLockedValue<T>
{
   // ReSharper disable once FieldCanBeMadeReadOnly.Local
   private          SpinLock spinLock;
   private          T        value;
   private readonly bool     useMemoryBarrier;

   /// <summary>
   /// Creates an instance of a <see cref="SpinLockedValue{T}"/>
   /// </summary>
   /// <param name="initialValue">The initial value</param>
   /// <param name="useMemoryBarrier">Indicates if the call to Exit should use a memory barrier to notify other threads the lock has been freed(much slower!).</param>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public SpinLockedValue(T initialValue = default, bool useMemoryBarrier=false)
   {
      this.useMemoryBarrier = useMemoryBarrier;
      value     = initialValue;
   }
   
   /// <summary>
   /// Sets or gets the value. This may block.
   /// </summary>
   public T Value
   {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get
      {
         T result=default;
         
         bool lockTaken = false;

         try
         {
            spinLock.TryEnter(-1, ref lockTaken);
            result = value;
         }
         finally
         {
            if (lockTaken)
               spinLock.Exit(useMemoryBarrier);
         }

         return result;
      }
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set
      {
         bool lockTaken = false;

         try
         {
            spinLock.TryEnter(-1, ref lockTaken);
            this.value = value;
         }
         finally
         {
            if (lockTaken)
               spinLock.Exit(useMemoryBarrier);
         }
      }
   }
}