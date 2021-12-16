using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlockingCollectionApp
{
    internal class Producer
    {
        private List<int> _collection;
        private readonly AutoResetEvent writeDoneEvent;
        private readonly AutoResetEvent readDoneEvent;

        public Producer(List<int> collection, AutoResetEvent writeDoneEvent, AutoResetEvent readDoneEvent)
        {
            _collection = collection;
            this.writeDoneEvent = writeDoneEvent;
            this.readDoneEvent = readDoneEvent;
        }

        public void Produce()
        {
            Random random = new Random();
            while (true)
            {
                readDoneEvent.WaitOne();
                Thread.Sleep(100);
                _collection.Add(random.Next());
                writeDoneEvent.Set();
            }
        }
    }
}
