using System;
using System.Collections.Generic;
using System.Text;
using CatchIoScriptImpl.Items;

namespace CatchIoScriptImpl.PlayerCharacter
{
    class PlayerHitbox : IDamageable
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
