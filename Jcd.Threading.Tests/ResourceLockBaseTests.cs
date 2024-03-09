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
   private readonly List<Action> waitActionSequence = new();

   public static Builder Create()
   {
      return new Builder();
   }
   
   public override bool Wait()
   {
      foreach (var action in waitActionSequence)
      {
         action?.Invoke();
      }
      return true;
   }

   public override bool Wait(CancellationToken token)
   {
      return Wait();
   }

   public override Task<bool> WaitAsync()
   {
      return Task.FromResult(Wait());
   }

   public override Task<bool> WaitAsync(CancellationToken token)
   {
      return Task.FromResult(Wait(token));
   }

   public override void Release() {  }

   public override void Dispose() {  }

   public class Builder
   {
      private readonly Harness harness = new ();
      public Builder AddAction(Action action)
      {
         harness.waitActionSequence.Add(action);
         return this;
      }
      
      public Builder CallBeginWait()    => AddAction(() => harness.BeginWait());
      public Builder CallLockAcquired() => AddAction(() => harness.LockAcquired());
      public Builder CallEndWait()      => AddAction(() => harness.EndWait());
      
      public Builder CallRelease()      => AddAction(() => harness.Release());
      public Harness Build()            => harness;

   }
}
#endregion
}