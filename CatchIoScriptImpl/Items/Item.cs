// Copyright (c) Team STEP.  All Rights Reserved.

using System;

namespace CatchIoScriptImpl.Items
{
    public abstract class Item
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
