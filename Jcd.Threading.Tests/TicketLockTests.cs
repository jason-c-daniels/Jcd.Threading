using Jcd.Threading.SynchronizedValues;

namespace Jcd.Threading.Tests;

public class TicketLockTests
{
   [Fact]
   public void Lock_Returns_A_Ticket_With_The_Expected_Id()
   {
      var     tl            = new TicketLock();
      var     expectedValue = tl.NowServing;
      ITicket t, t2, t3;
      using (t = tl.Lock())
         Assert.Equal(expectedValue, t.TicketId);
      using (t2 = tl.Lock())
         Assert.Equal(t.TicketId + 1, t2.TicketId);
      using (t3 = tl.Lock())
         Assert.Equal(t2.TicketId + 1, t3.TicketId);
   }

   [Fact]
   public void Lock_With_CancellationToken_Returns_A_Ticket_With_The_Expected_Id()
   {
      CancellationTokenSource cts           = new();
      var                     tl            = new TicketLock();
      var                     expectedValue = tl.NowServing;
      ITicket                 t, t2, t3;
      using (t = tl.Lock(cts.Token))
         Assert.Equal(expectedValue, t.TicketId);
      using (t2 = tl.Lock(cts.Token))
         Assert.Equal(t.TicketId + 1, t2.TicketId);
      using (t3 = tl.Lock(cts.Token))
         Assert.Equal(t2.TicketId + 1, t3.TicketId);
   }
   
   [Fact]
   public void Lock_With_CancellationToken_That_Gets_Cancelled_Returns_A_Ticket_That_Becomes_Cancelled()
   {
      CancellationTokenSource         cts           = new();
      var                             tl            = new TicketLock();
      ReaderWriterLockSlimValue<bool> done =new ();
      var                             are  = new ManualResetEvent(false);
      var                             mre  = new ManualResetEvent(false);
      mre.Reset();
      are.Reset();
      var task = Task.Run(() =>
                          {
                             using (_ = tl.Lock(cts.Token))
                             {
                                mre.Set();
                                are.WaitOne();
                             }

                             done.Value = true;
                          }
                        , cts.Token
                         );
      var task2 = Task.Run(() =>
                           {
                              mre.WaitOne();
                              Thread.Sleep(100);
                              are.Set();
                              cts.Cancel();
                           }
                         , cts.Token
                          );
      mre.WaitOne();
      are.WaitOne();
      using var ticket = tl.Lock(cts.Token);
      var sw     = new SpinWait();
      while (!done.Value) sw.SpinOnce(10);
      
      Assert.True(ticket.IsCanceled);
      
      #pragma warning disable xUnit1031
      // this is intentional and will not deadlock.
      Task.WaitAll([task, task2 ]);
      #pragma warning restore xUnit1031
   }

   
   [Fact]
   public void Lock_With_Cancelled_CancellationToken_Returns_A_Ticket_With_The_Expected_Status()
   {
      CancellationTokenSource cts           = new();
      cts.Cancel();
      var                     tl            = new TicketLock();
      ITicket                 t, t2, t3;
      using (t = tl.Lock(cts.Token))
         Assert.True(t.IsCanceled);
      using (t2 = tl.Lock(cts.Token))
         Assert.True(t2.IsCanceled);
      using (t3 = tl.Lock(cts.Token))
         Assert.True(t3.IsCanceled);
   }

   [Fact]
   public async Task LockAsync_Returns_A_Ticket_With_The_Expected_Id()
   {
      var     tl            = new TicketLock();
      var     expectedValue = tl.NowServing;
      ITicket t, t2, t3;
      using (t = await tl.LockAsync())
         Assert.Equal(expectedValue, t.TicketId);
      using (t2 = await tl.LockAsync())
         Assert.Equal(t.TicketId + 1, t2.TicketId);
      using (t3 = await tl.LockAsync())
         Assert.Equal(t2.TicketId + 1, t3.TicketId);
   }

   [Fact]
   public async Task LockAsync_With_Cancellation_Token_Returns_A_Ticket_With_The_Expected_Id()
   {
      CancellationTokenSource cts           = new();
      var                     tl            = new TicketLock();
      var                     expectedValue = tl.NowServing;
      ITicket                 t, t2, t3;
      using (t = await tl.LockAsync(cts.Token))
         Assert.Equal(expectedValue, t.TicketId);
      using (t2 = await tl.LockAsync(cts.Token))
         Assert.Equal(t.TicketId + 1, t2.TicketId);
      using (t3 = await tl.LockAsync(cts.Token))
         Assert.Equal(t2.TicketId + 1, t3.TicketId);
   }

   [Fact]
   public async Task LockAsync_With_CancellationToken_That_Gets_Cancelled_Returns_A_Ticket_That_Becomes_Cancelled()
   {
      CancellationTokenSource         cts  = new();
      var                             tl   = new TicketLock();
      ReaderWriterLockSlimValue<bool> done =new ();
      var                             are  = new ManualResetEvent(false);
      var                             mre  = new ManualResetEvent(false);
      mre.Reset();
      are.Reset();
      var task = Task.Run(async () =>
                          {
                             using (_ = await tl.LockAsync(cts.Token))
                             {
                                mre.Set();
                                are.WaitOne();
                             }

                             done.Value = true;
                          }
                        , cts.Token
                         );
      var task2 = Task.Run(async () =>
                           {
                              mre.WaitOne();
                              await Task.Delay(100, cts.Token);
                              are.Set();
                              await cts.CancelAsync();
                           }
                         , cts.Token
                          );
      mre.WaitOne();
      are.WaitOne();
      using var ticket = await tl.LockAsync(cts.Token);
      var sw     = new SpinWait();
      while (!done.Value) sw.SpinOnce(10);
      Thread.Sleep(150);
      Assert.True(ticket.IsCanceled);
      await Task.WhenAll([task, task2 ]);
   }

   [Fact]
   public void CurrentCount_Returns_Expected_Value()
   {
      var       tl            = new TicketLock();
      using var t             = tl.GetTicket();
      using var t2            = tl.GetTicket();
      using var t3            = tl.GetTicket();
      Assert.Equal(3, tl.CurrentCount);
      t.Wait();
      t.Release();
      Assert.Equal(2, tl.CurrentCount);
   }

   [Fact]
   public void NowServing_Returns_Expected_Value()
   {
      var       tl            = new TicketLock();
      using var t             = tl.GetTicket();
      using var t2            = tl.GetTicket();
      using var t3            = tl.GetTicket();
      Assert.Equal(t.TicketId, tl.NowServing);
      t.Wait();
      t.Release();
      Assert.Equal(t2.TicketId, tl.NowServing);
   }

   [Fact]
   public void MaxTicketCount_Is_Long_MaxValue()
   {
      var tl = new TicketLock();
      Assert.Equal(long.MaxValue, tl.MaxTicketCount);
   }
}