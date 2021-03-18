// Copyright (c) Team STEP.  All Rights Reserved.

using CatchIoScriptImpl.Items;

namespace CatchIoScriptImpl.PlayerCharacter
{
    public class PlayerHitbox : IDamageable
    {
        // cache the Player component on start
        private readonly Player _player;

        public PlayerHitbox(Player owner)
        {
            _player = owner;
        }

        public void OnDamage(float damage)
        {
            _player.TakeDamage(damage);
            // todo: add other damage effects
        }

        public void OnTriggerEnter(object other)
        {
            // pattern matching an object in the collision check method might be horrible for performance
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
