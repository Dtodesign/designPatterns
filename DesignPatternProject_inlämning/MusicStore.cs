using System;
using System.Collections.Generic;

namespace DesignPatternProject_inlämning
{
    public class MusicStore :IObserver<Album>
    {

        

        private readonly List<Album> albums = new List<Album>();
        private readonly SortedList<RecordLabel, IDisposable> _Cancel = new SortedList<RecordLabel, IDisposable>();

        public string StoreName { get; set; }

        public MusicStore()
        {

        }
        public MusicStore(string storeName)
        {
            StoreName = storeName;
        }

        public void OnCompleted()
        {
            albums.Clear();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public virtual void OnNext(Album alb)
        {
            if (albums.Contains(alb))
            {
                return;
            }
            albums.Add(alb);
            Console.WriteLine("{0} Ordered {1} with Album Title {2} "
                , StoreName, alb.Name, alb.ArtistName);
        }

        public virtual void Subscribe(RecordLabel rcLabel)
        {
            _Cancel.Add(rcLabel, rcLabel.Subscribe(this));

            Console.WriteLine("{0} Subscribed to {1}", StoreName,rcLabel.CompanyName);

        }

        public void Test(Album al)
        {
            Console.WriteLine("{0} Ordered {1} with Album Title {2} "
                , StoreName, al.Name, al.ArtistName);
        }
        public virtual void Unsubscribe(RecordLabel rcLabel)
        {
            _Cancel[rcLabel].Dispose();

            albums.RemoveAll(x => x.RecordLabel == rcLabel);

            Console.WriteLine("{0} Unsubscribed from {1}", StoreName, rcLabel.CompanyName);
        }

    }
}
