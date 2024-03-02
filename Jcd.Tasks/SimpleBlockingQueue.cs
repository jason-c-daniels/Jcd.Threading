using System.Collections.Generic;
using System.Threading;

namespace Jcd.Tasks;

public class SimpleBlockingQueue<TItem> //: IEnumerable<TItem>
{
   private readonly Queue<TItem> itemQueue = new();

   private readonly SemaphoreSlim queueSem = new(1, 1);
   
   
}