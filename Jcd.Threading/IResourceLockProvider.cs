namespace Jcd.Threading;

/// <summary>
/// Provides a mechanism for acquiring resource locks bound to a specific instance of a synchronization primitive.
/// </summary>
/// <typeparam name="T">The type of the resource lock.</typeparam>
public interface IResourceLockProvider<out T>
   where T : IResourceLock
{
   /// <summary>
   /// Acquires a resource lock bound to a synchronization primitive instance.
   /// </summary>
   /// <returns>A resource lock bound to a synchronization primitive instance.</returns>
   T GetResourceLock();
}