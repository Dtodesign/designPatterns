using System;
using System.Collections.Generic;

namespace DesignPatternProject_inlämning
{
    public class AlbumOrderList
    {
        public List<Album> order { get; set; }
        public AlbumOrderList()
        {
            order = new List<Album>();
        }

        public void ExecuteCommand(OrderCommand cmd, Album album)  
        {
            cmd.Execute(this.order, album);
        }

        public void ShowOrder()
        {
            foreach (var item in order)
            {
                item.ShowAlbumDetails();
            }
            Console.WriteLine("\n");
        }
    }
}
