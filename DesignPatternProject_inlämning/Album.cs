using System;
namespace DesignPatternProject_inlämning
{
    public class Album 
    {

        public string  Name { get; set; }
        public string ArtistName { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public RecordLabel RecordLabel { get; set; }
       


        public Album(string name, string artistName,int amount, double price)
        {
            Name = name;
            Amount = amount;
            Price = price;
            ArtistName = artistName;
        }

        public Album(string name, string artistName, double price)
        {
            Name = name;
            Price = price;
            ArtistName = artistName;
        }

        public Album(string name, string artistName, double price, RecordLabel recordLabel)
        {
            Name = name;
            Price = price;
            ArtistName = artistName;
            RecordLabel = recordLabel;
        }

        public void ShowAlbumDetails() {
            
            Console.WriteLine("\nAlbum Name: " + Name);
            Console.WriteLine("\nArtist Name: " + ArtistName);
            Console.WriteLine("\nAmount: " + Amount.ToString());
            Console.WriteLine("\nAlbum Price: $" + Price.ToString());
            Console.WriteLine("\n");

        }

        

    }
}
