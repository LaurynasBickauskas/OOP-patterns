using System;
using System.Collections.Generic;

namespace CosmosInvaders.Library
{
    public class ObservableShips : IObservable
    {
        private List<IObserver> _observers { get; set; }
        private Game _gameInstance { get; set; }

        public ObservableShips(Game instance)
        {
            _observers = new List<IObserver>();
            _gameInstance = instance;

        }

        public void Add(IObserver o)
        {
            if(!_observers.Contains(o))
                _observers.Add(o);
        }

        public void Remove(IObserver o)
        {
            if (_observers.Contains(o))
                _observers.Remove(o);
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }

        public void NotifyAll()
        {
            foreach (IObserver observer in _observers)
                observer.Update();
        }
    }
}