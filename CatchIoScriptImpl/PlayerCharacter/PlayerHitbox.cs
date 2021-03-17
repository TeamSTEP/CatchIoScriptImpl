// Copyright (c) Team STEP.  All Rights Reserved.

using CatchIoScriptImpl.Items;

namespace CatchIoScriptImpl.PlayerCharacter
{
    public class PlayerHitbox : IDamageable
    {
        private readonly Player _player;

        public PlayerHitbox(Player owner)
        {
            _player = owner;
        }

        public void OnDamage(float damage)
        {
            _player.TakeDamage(damage);
        }

        public void OnTriggerEnter(object other)
        {
            switch (other)
            {
                case OffensiveThrowableItem item:
                    item.OnHit(this);
                    break;
                case Item item:
                    _player.PickupItem(item);
                    break;
            }
        }
    }
}
