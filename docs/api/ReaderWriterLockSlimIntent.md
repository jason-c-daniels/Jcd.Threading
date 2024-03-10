#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## ReaderWriterLockSlimIntent Enum

Indicates the intent of a call to [ReaderWriterLockSlimExtensions](ReaderWriterLockSlimExtensions.md 'Jcd.Threading.ReaderWriterLockSlimExtensions')`Lock`.

```csharp
public enum ReaderWriterLockSlimIntent
```
### Fields

<a name='Jcd.Threading.ReaderWriterLockSlimIntent.Read'></a>

`Read` 0

The lock is being used to read data.

<a name='Jcd.Threading.ReaderWriterLockSlimIntent.UpgradeableRead'></a>

`UpgradeableRead` 1

The lock is being used to read, at first, but can be upgraded to a write.

<a name='Jcd.Threading.ReaderWriterLockSlimIntent.Write'></a>

`Write` 2

The lock is being used for writing.