using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    public interface IObservable
    {
        public void Add(IObserver obs);
        public void Remove(IObserver obs);
        public void notify();
    }
}
