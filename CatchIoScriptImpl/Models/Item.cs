using System;
using System.Collections.Generic;
using System.Text;
using CatchIoScriptImpl.Interfaces;

namespace CatchIoScriptImpl.Models
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

    abstract class ConsumableItem : Item
    {
        public abstract void Consume();
    }

    abstract class OffensiveThrowableItem : ThrowableItem
    {
        public abstract float DamageVal { get; }

        public virtual void OnHit(IDamageable other)
        {
            other.OnDamage(DamageVal);
        }
    }
}
