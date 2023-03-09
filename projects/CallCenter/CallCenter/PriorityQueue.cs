using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter
{
    public class PriorityQueue
    {
        public List<Customer> queue = new List<Customer>();

        public void Enqueue(Customer customer)
        {
            queue.Add(customer); // add the customer to the end of the queue
            queue.Sort((x, y) => y.priority.CompareTo(x.priority)); // sort the queue by priority
        }

        public Customer Dequeue()
        {
            Customer customer = queue[0]; // gets the first customer in the queue
            
            queue.RemoveAt(0); // removes the customer from the queue
            return customer; // returns the customer that was removed from the queue
        }

        public int Count
        {
            get { return queue.Count; } 
        }
    }
}
