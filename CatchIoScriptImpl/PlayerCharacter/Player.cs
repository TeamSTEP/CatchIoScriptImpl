using System;
using CatchIoScriptImpl.Items;

namespace CatchIoScriptImpl.PlayerCharacter
{
    class Player
    {
        public string name = "Test Player";
        public string charSkin = "Druid_A";
#nullable enable
        public Item? holdingItem;
#nullable disable
        public float staminaVal = 0;
        public float sanityVal = 10;
        public bool canControl = true;
        public bool CanBeKilled
        {
            get
            {
                return sanityVal == 0;
            }
        }

        public Action<Item> AddItemToInventoryAction;
        public Action RemoveHoldingItemAction;

        public void Attack(IDamageable other)
        {
            float damage = 4f;

            other.OnDamage(damage);
        }

        public void ThrowItem(ThrowableItem item)
        {
            item.Throw();
            RemoveHoldingItemAction();
        }

        public void ConsumeItem(ConsumableItem item)
        {
            item.Consume(this);
            RemoveHoldingItemAction();
        }

        public void PickupItem(Item item)
        {
            item.Pickup();
            AddItemToInventoryAction(item);
        }

        public void DiscardItem(Item item)
        {
            if (holdingItem != null)
            {
                item.Discard();
                holdingItem = null;
            }
        }

        public void TakeDamage(float damage)
        {
            Console.WriteLine($"Player took {damage} damage");

            if (CanBeKilled)
            {
                Console.WriteLine($"Player {name} died!");
            }
            else
            {
                if (staminaVal != 0)
                {
                    staminaVal = staminaVal - damage;
                    if (staminaVal < 0)
                    {
                        sanityVal = sanityVal - Math.Abs(staminaVal);
                        staminaVal = 0;
                    }
                }
                else if (sanityVal != 0)
                {
                    sanityVal = sanityVal - damage;
                    if (sanityVal < 0)
                    {
                        sanityVal = 0;
                    }
                }
            }

        }

        public void Draw()
        {
            Console.WriteLine($"Name : {name}, HoldingItem : {holdingItem}, Stamina : {staminaVal}, Sanity : {sanityVal}");
        }
    }
}
