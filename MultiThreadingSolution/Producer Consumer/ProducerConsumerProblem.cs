using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Producer_Consumer
{
    public class ProducerConsumerProblem
    {
        private readonly object _lock = new object();
        private readonly Queue<int> queue = new Queue<int>();


        public void Produce(int input)
        {
            lock (_lock)
            {
                queue.Enqueue(input);
                Monitor.Pulse(_lock);
            }
        }

        public int Consume()
        {
            lock (_lock)
            {
                while (!queue.Any())
                {
                    Monitor.Wait(_lock);
                }

                return queue.Dequeue();
            }
        }
    }
}
