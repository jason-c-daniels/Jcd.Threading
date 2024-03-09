// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.ObjectAllocation

namespace Jcd.Threading.Tests;

public class ResourceLockBaseTests
{
   [Fact]
   public void BeginWait_Throws_InvalidOperationException_When_Called_Twice_In_A_Row()
   {
      var sut = Harness.Create()
                       .CallBeginWait()
                       .CallBeginWait()
                       .Build();
      Assert.Throws<InvalidOperationException>(() => sut.Wait());
   }

   [Fact]
   public void EndWait_Throws_InvalidOperationException_When_Called_Twice_In_A_Row()
   {
      var sut = Harness.Create()
                       .CallBeginWait()
                       .CallEndWait()
                       .CallEndWait()
                       .Build();
      Assert.Throws<InvalidOperationException>(() => sut.Wait());
   }

   [Fact]
   public void EndWait_Throws_InvalidOperationException_When_Called_Without_Calling_BeginWait()
   {
      var sut = Harness.Create()
                       .CallEndWait()
                       .Build();
      Assert.Throws<InvalidOperationException>(() => sut.Wait());
   }

   [Fact]
   public void LockAcquired_Throws_InvalidOperationException_When_Called_Twice_In_A_Row()
   {
      var sut = Harness.Create()
                       .CallBeginWait()
                       .CallLockAcquired()
                       .CallLockAcquired()
                       .Build();
      Assert.Throws<InvalidOperationException>(() => sut.Wait());
   }

   #region Harness

   public class Harness : ResourceLockBase
   {
      private readonly List<Action> waitActionSequence = [];

      public static Builder Create() { return new Builder(); }

      public override bool Wait()
      {
         foreach (var action in waitActionSequence) action.Invoke();

         return true;
      }

      public override bool Wait(CancellationToken token) { return Wait(); }

      public override Task<bool> WaitAsync() { return Task.FromResult(Wait()); }

      public override Task<bool> WaitAsync(CancellationToken token) { return Task.FromResult(Wait(token)); }

      public override void Release() { }

      #pragma warning disable CA1816
      public override void Dispose() { }
      #pragma warning restore CA1816

      public class Builder
      {
         private readonly Harness harness = new();

         public Builder AddAction(Action action)
         {
            harness.waitActionSequence.Add(action);

            return this;
         }

         public Builder CallBeginWait() { return AddAction(() => harness.BeginWait()); }

         public Builder CallLockAcquired() { return AddAction(() => harness.LockAcquired()); }

         public Builder CallEndWait() { return AddAction(() => harness.EndWait()); }

         public Harness Build() { return harness; }
      }
   }

   #endregion
}