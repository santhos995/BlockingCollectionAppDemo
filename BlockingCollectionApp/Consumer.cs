using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlockingCollectionApp
{
    internal class Consumer
    {
        private readonly int i;
        private List<int> _collection;
        private readonly AutoResetEvent writeDoneEvent;
        private readonly AutoResetEvent readDoneEvent;

        public Consumer(int i, List<int> collection, AutoResetEvent writeDoneEvent, AutoResetEvent readDoneEvent)
        {
            this.i = i;
            _collection = collection;
            this.writeDoneEvent = writeDoneEvent;
            this.readDoneEvent = readDoneEvent;
        }

        public void Consume()
        {
            while (true)
            {
                writeDoneEvent.WaitOne();
                Console.WriteLine($"Consumed by {i}, value - { _collection.First()}");
                _collection.RemoveAt(0);
                readDoneEvent.Set();//signalling the producer to produce
            }
        }
    }
}
