using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Neo4jSharp
{
    public class GenericAsyncResult<T> : IAsyncResult
    {
      
        public GenericAsyncResult(object state, AsyncCallback callback)
        {
            this.callback = callback;
            AsyncState = state;
            ResetEvent = new ManualResetEvent(false);
        }

        public object AsyncState
        {
            get;
            set;
        }

        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get
            {
                return ResetEvent;
            }
        }

        public bool CompletedSynchronously
        {
            get { return false; }
        }

        public bool IsCompleted
        {
            get;
            set;
        }

        public ManualResetEvent ResetEvent
        {
            get;
            set;
        }

        public T Data { get; set; }


        public void Finished()
        {

            ResetEvent.Set();
            IsCompleted = true;
            if (callback != null)
                callback(this);
            
        }
        private AsyncCallback callback;
    }
}
