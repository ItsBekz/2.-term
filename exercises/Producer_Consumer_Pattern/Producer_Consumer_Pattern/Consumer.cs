using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer_Consumer_Pattern
{
    public class Consumer
    {
        private Queue _queue; // this is the queue that the producer will add nodes to
        private int _maxSize; // this is the maximum size of the queue

        public Consumer(Queue queue, int maxSize)
        {
            _queue = queue;
            _maxSize = maxSize;
        }

        public Node Consume()
        {
            return _queue.Dequeue();
        }
    }
}
