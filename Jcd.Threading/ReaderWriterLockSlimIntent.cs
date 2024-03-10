namespace Jcd.Threading;

/// <summary>
/// Indicates the intent of a call to <see cref="ReaderWriterLockSlimExtensions"/>`Lock`.
/// </summary>
public enum ReaderWriterLockSlimIntent
{
   /// <summary>
   /// The lock is being used to read data.
   /// </summary>
   Read

  ,

   /// <summary>
   /// The lock is being used to read, at first, but can be upgraded to a write.
   /// </summary>
   UpgradeableRead

  ,

   /// <summary>
   /// The lock is being used for writing.
   /// </summary>
   Write
}