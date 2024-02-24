using System.Threading;

namespace Jcd.Tasks;

/// <summary>
/// Provides two STA threads
/// </summary>
public class DualSTAThreadScheduler : STAThreadScheduler
{
   public DualSTAThreadScheduler() : base(2)
   {
      
   }
}