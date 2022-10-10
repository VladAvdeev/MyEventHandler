using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyEventHandler
{
    internal class AsyncCaller
    {
        private readonly EventHandler eventHandler;ы

        public AsyncCaller(EventHandler eventHandler)
        {
            this.eventHandler = eventHandler;
        }
        public bool Invoke(int timeout, object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { eventHandler.Invoke(sender, e); });
            thread.Start();
            thread.Join();
            return thread.Join(timeout);
        }
    }
}
