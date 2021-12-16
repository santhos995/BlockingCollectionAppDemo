using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlockingCollectionApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int>();
            AutoResetEvent writeDoneEvent = new AutoResetEvent(false);
            AutoResetEvent readDoneEvent  = new AutoResetEvent(true);
            
            
            Producer producer = new Producer(collection, writeDoneEvent, readDoneEvent);
            Consumer consumer = new Consumer(1, collection, writeDoneEvent, readDoneEvent);
            Consumer consumer2 = new Consumer(2, collection, writeDoneEvent, readDoneEvent);


            Task t1 = Task.Factory.StartNew(() => producer.Produce());
            Task t2 = Task.Factory.StartNew(() => consumer.Consume());
            Task t3 = Task.Factory.StartNew(() => consumer2.Consume());

            Task.WhenAll(t1, t2,t3);
            Console.WriteLine("Done");
            Console.ReadLine();

            //produce thread will produce data and it will publish an event to consumer
            //consumer will consume the data and inform produce that I have read the data and you can produce again
    }
    }
}
