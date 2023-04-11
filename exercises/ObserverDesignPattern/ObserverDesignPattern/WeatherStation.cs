using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    public class WeatherStation : IObservable
    {
        private List<IObserver> observers;

        public WeatherStation()
        {
            observers = new List<IObserver>();
        }

        public void Add(IObserver obs)
        {
            observers.Add(obs);
        }

        public void Remove(IObserver obs)
        {
            observers.Remove(obs);
        }

        public void notify()
        {
            foreach (IObserver obs in observers)
            {
                obs.update();
            }
        }

        public void setMeasurements(int temperature, int humidity, int pressure)
        {
            notify();
        }
    }
}
