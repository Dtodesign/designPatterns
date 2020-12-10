using System;
using System.Collections.Generic;

namespace DesignPatternProject_inlämning
{
    internal class Unsunscriber<T> : IDisposable
    {
        private List<IObserver<Album>> _observers;
        private IObserver<Album> _observer;

        public Unsunscriber(List<IObserver<Album>> observers, IObserver<Album> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
