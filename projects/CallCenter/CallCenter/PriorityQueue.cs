using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter
{
    public class PriorityQueue
    {
        private List<Customer> queue = new List<Customer>();

        public void Enqueue(Customer customer)
        {
            queue.Add(customer);
            queue.Sort((x, y) => y.priority.CompareTo(x.priority));
        }

        public Customer Dequeue()
        {
            Customer customer = queue[0];
            queue.RemoveAt(0);
            return customer;
        }

        public int Count
        {
            get { return queue.Count; }
        }
    }
}
