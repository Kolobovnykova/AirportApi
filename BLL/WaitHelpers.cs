using System.Threading.Tasks;
using System.Timers;

namespace BLL
{
    public static class WaitHelpers
    {
        public static Task WaitHelper(int ms)
        {
            var source = new TaskCompletionSource<object>();
            var timer = new Timer(ms);
            timer.Elapsed += (o, e) => { source.TrySetResult(null); };
            timer.Start();
            return source.Task;
        }
    }
}