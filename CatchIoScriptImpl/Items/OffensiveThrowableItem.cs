// Copyright (c) Team STEP.  All Rights Reserved.

using CatchIoScriptImpl.PlayerCharacter;

namespace CatchIoScriptImpl.Items
{
    public abstract class OffensiveThrowableItem : ThrowableItem
    {
        public abstract float DamageVal { get; }

        public virtual void OnHit(IDamageable other)
        {
            other.OnDamage(DamageVal);
        }
    }
}
