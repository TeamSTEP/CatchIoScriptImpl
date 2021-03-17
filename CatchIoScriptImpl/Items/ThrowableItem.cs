// Copyright (c) Team STEP.  All Rights Reserved.

using System;

namespace CatchIoScriptImpl.Items
{
    public abstract class ThrowableItem : Item
    {
        public virtual void Throw()
        {
            Console.WriteLine("Throwing Item");
        }

        public virtual void OnLanded()
        {
            Console.WriteLine("Item has landed");
        }
    }
}
