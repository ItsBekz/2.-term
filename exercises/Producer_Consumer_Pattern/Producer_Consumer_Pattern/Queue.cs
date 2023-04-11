using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Producer_Consumer_Pattern
{
    public class Queue
    {
        private List<Node> _queue = new List<Node>(); // list of Nodes in the queue
        private int _maxSize = 5; // max size of the list
        public bool isFull = false;

        public Queue(int maxSize)
        {
            _maxSize = maxSize; // sets max size
        }

        public void Enqueue(Node node) // queues a node
        {
            if (_queue.Count < _maxSize) // if the queue is less than max
            {
                _queue.Add(node); // add the node to the queue
            }
        }

        public Node Dequeue() // unqueues a node
        {
            if (_queue.Count > 0) // if the queue is bigger than 0
            {
                Node node = _queue[0]; // creates a node placeholder and sets it equal to the first node in the queue
                _queue.RemoveAt(0); // removes the first node in the queue
                return node; // returns the node that was just removed
            }
            return null;
        }

        public int Count()
        {
            return _queue.Count;
        }
    }
}
