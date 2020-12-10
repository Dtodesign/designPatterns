using System;

namespace DesignPatternProject_inlämning
{
    class Program
    {
        static void Main(string[] args)
        {
            RecordLabel rec1 = new RecordLabel("Rec1");


            MusicStore store1 = new MusicStore("Store1");

            

            store1.Subscribe(rec1);

            rec1.Display("KOKO", "POPO", 23.23);


            rec1.Order();
            rec1.CheckOrder(new Album("KOKO", "POPO", 1, 23.23));
            rec1.ExecuteCommand();

            

            rec1.Order();
            rec1.CheckOrder(new Album("TEST", "TEST", 2, 11.11));
            rec1.ExecuteCommand();

           


            rec1.ModifyOrder();
            rec1.CheckOrder(new Album("KOKO", "POPO", 10, 23.23));
            rec1.ExecuteCommand();

            


            rec1.UndoOrder();
            rec1.ExecuteCommand();
            Console.WriteLine("----- Orders In Process After Undo Command -----");
            rec1.DisplayOrders();


            rec1.RedoOrder();
            rec1.ExecuteCommand();


            Console.WriteLine("----- Orders In Process  After Redo Command -----");
            rec1.DisplayOrders();


            RecordLabel rc2 = new RecordLabel("RecordLabel2");

            MusicStore store2 = new MusicStore("Store2");
            MusicStore store3 = new MusicStore("Store2");

            store2.Subscribe(rc2);
            store3.Subscribe(rc2);


            store1.Unsubscribe(rec1);


        }
    }
}
