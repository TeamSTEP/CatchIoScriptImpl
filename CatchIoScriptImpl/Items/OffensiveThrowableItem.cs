using System;
using System.Collections.Generic;
using System.Text;
using CatchIoScriptImpl.PlayerCharacter;

namespace CatchIoScriptImpl.Items
{
    abstract class OffensiveThrowableItem : ThrowableItem
    {
        public abstract float DamageVal { get; }

        public virtual void OnHit(IDamageable other)
        {
            other.OnDamage(DamageVal);
        }
    }
}
