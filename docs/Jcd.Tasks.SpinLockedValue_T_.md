### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## SpinLockedValue<T> Class

Provides synchronization to an underlying value through a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock').

```csharp
internal class SpinLockedValue<T>
```
#### Type parameters

<a name='Jcd.Tasks.SpinLockedValue_T_.T'></a>

`T`

The type of the data being stored.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SpinLockedValue<T>

| Constructors | |
| :--- | :--- |
| [SpinLockedValue(T, bool)](Jcd.Tasks.SpinLockedValue_T_.SpinLockedValue(T,bool).md 'Jcd.Tasks.SpinLockedValue<T>.SpinLockedValue(T, bool)') | Creates an instance of a [SpinLockedValue&lt;T&gt;](Jcd.Tasks.SpinLockedValue_T_.md 'Jcd.Tasks.SpinLockedValue<T>') |

| Properties | |
| :--- | :--- |
| [Value](Jcd.Tasks.SpinLockedValue_T_.Value.md 'Jcd.Tasks.SpinLockedValue<T>.Value') | Sets or gets the value. This may block. |
