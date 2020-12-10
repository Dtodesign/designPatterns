using System;
using System.Collections.Generic;

namespace DesignPatternProject_inlämning
{
    
    public class RecordLabel : IObservable<Album>
    {


        private OrderCommand _cmdOrder;
        private Album albm;
        private AlbumOrderList _orderList;

      


        //private readonly List<MusicStore> _m = new List<MusicStore>();
        private readonly List<Album> _album = new List<Album>();
        private readonly List<IObserver<Album>> _observers = new List<IObserver<Album>>();

        public string  CompanyName { get; set; }
        

        public RecordLabel(string name)
        {
            CompanyName = name;
            _orderList = new AlbumOrderList();
        }

        public void Order()
        {
            _cmdOrder = new CreateOrderCommand();
        }

       

        public void CheckOrder(Album album)
        {
            albm = album;
        }

        public void UndoOrder()
        {
            _cmdOrder = new UndoOrderCommand();
        }

        public void RedoOrder()
        {
            _cmdOrder = new RedoOrderCommand();
        }
        public void ModifyOrder()
        {
            _cmdOrder = new UpdateOrderCommand();
        }

        public void ExecuteCommand()
        {
            _orderList.ExecuteCommand(_cmdOrder, albm);
        }


        public void DisplayOrders()
        {
            _orderList.ShowOrder();
        }


        public IDisposable Subscribe(IObserver<Album> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }

            return new Unsunscriber<Album>(_observers, observer);
        }

       
        public void Display(string name, string artistName, double price)
        {
            var album = new Album(name,artistName,price);

            if (_album.Contains(album))
            {
                return;
            }
            _album.Add(album);
            foreach (var observer in _observers)
            {
                observer.OnNext(album);
                

            }
            Console.WriteLine("Record Label {0} Publish Album {1} From {2} ----- \n",CompanyName, album.Name, album.ArtistName);
            
        }

        public void DeleteAllSubscribers()
        {
            foreach (var observer in _observers)
            {
                observer.OnCompleted();
            }
            _observers.Clear();
        }
        
    }
}
