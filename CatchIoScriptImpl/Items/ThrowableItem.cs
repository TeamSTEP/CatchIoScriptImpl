using System;
using System.Collections.Generic;
using System.Text;

namespace CatchIoScriptImpl.Items
{
    abstract class ThrowableItem : Item
    {
        public float CalculateProjectileMovePoints(float startPos, float endPos)
        {
            return startPos * endPos;
        }

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
