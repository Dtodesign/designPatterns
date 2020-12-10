using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternProject_inlämning
{
    public abstract class OrderCommand
    {
        public abstract void Execute(List<Album> order, Album newAlbum); 
        
    }

    public class CreateOrderCommand : OrderCommand
    {
        public override void Execute(List<Album> order, Album newAlbum)
        {
            order.Add(newAlbum);
            Console.WriteLine("------ Execute/Add Command ------\n");
            Console.WriteLine("Order With AlbumName {0} Has Been Processed!\n",newAlbum.Name);
            newAlbum.ShowAlbumDetails();
        }
    }

    public class UndoOrderCommand : OrderCommand
    {
        public override void Execute(List<Album> order, Album newAlbum)
        {
            order.Remove(order.Where(x => x.Name == newAlbum.Name).First());
            Console.WriteLine("------  Undo Command ------\n");
            Console.WriteLine("Album With The Name: {0} Has Been Deleted From The List!\n",newAlbum.Name);
            Console.WriteLine("\n");
        }
    }

    public class RedoOrderCommand : OrderCommand
    {
        public override void Execute(List<Album> order, Album newAlbum)
        {
            order.Add(newAlbum);
            Console.WriteLine("Order With AlbumName {0} Has Been Processed!\n", newAlbum.Name);
            newAlbum.ShowAlbumDetails();

        }
    }
    public class UpdateOrderCommand : OrderCommand
    {
        public override void Execute(List<Album> order, Album newAlbum)
        {
            var item = order.Where(x => x.Name == newAlbum.Name).First();
            item.Price = newAlbum.Price;
            item.Amount = newAlbum.Amount;
            Console.WriteLine("------ Modify Command ------\n");
            Console.WriteLine($"Order With Album Name: {newAlbum.Name} Has Been Updated!\n");
            newAlbum.ShowAlbumDetails();
        }
    }
}
