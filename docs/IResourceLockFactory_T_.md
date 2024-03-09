#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## IResourceLockFactory<T> Interface

Provides a mechanism for acquiring resource locks bound to a specific instance of a synchronization primitive.

```csharp
public interface IResourceLockFactory<out T>
    where T : Jcd.Threading.IResourceLock
```
#### Type parameters

<a name='Jcd.Threading.IResourceLockFactory_T_.T'></a>

`T`

The type of the resource lock.

Derived  
&#8627; [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock')

| Methods | |
| :--- | :--- |
| [GetResourceLock()](IResourceLockFactory_T_.GetResourceLock().md 'Jcd.Threading.IResourceLockFactory<T>.GetResourceLock()') | Acquires a resource lock bound to a synchronization primitive instance. |
