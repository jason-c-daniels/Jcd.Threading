### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## ReaderWriterLockSlimExtensions Class

A set of extension methods to simplify using a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')  
to ensure the correct pair of EnterRead+ExitRead, EnterUpgradeableRead+ExitUpgradeableRead,  
and EnterWrite+ExitWrite are called.

```csharp
public static class ReaderWriterLockSlimExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ReaderWriterLockSlimExtensions