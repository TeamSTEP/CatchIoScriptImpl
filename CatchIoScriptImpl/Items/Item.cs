using System;

namespace CatchIoScriptImpl.Items
{
    abstract class Item
    {
        public void Pickup()
        {
            Console.WriteLine("Picking Up Item");
        }

        public void Discard()
        {
            Console.WriteLine("Discarding Item");
        }
    }

}
