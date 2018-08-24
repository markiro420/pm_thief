using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrystalGeneric
{
    public abstract class UnitControllerBase
    {
        AutoResetEvent threadHolder;
        Timer timer;

        public TimeSpan UpdSpan { get; set; } = TimeSpan.FromSeconds(5);

        public void RunAsync()
        {
            Task.Run((Action)Run);
        }

        public void Run()
        {
            threadHolder = new AutoResetEvent(false);
            timer = new Timer(Cycle, threadHolder, TimeSpan.FromMilliseconds(20), UpdSpan);
            threadHolder.WaitOne();
            timer.Dispose();
        }

        protected void Cycle(object state)
        {
            Refresh();
        }

        public void Break()
        {
            threadHolder.Set();
        }

        protected abstract void Refresh();
    }

}
