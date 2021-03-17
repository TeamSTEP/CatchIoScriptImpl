// Copyright (c) Team STEP.  All Rights Reserved.

using System;
using CatchIoScriptImpl.Items;

namespace CatchIoScriptImpl.PlayerCharacter
{
    public class Player
    {
        public string Name = "Test Player";
        public string CharSkin = "Druid_A";
#nullable enable
        public Item? HoldingItem;
#nullable disable
        public float StaminaVal = 0;
        public float SanityVal = 10;
        public bool CanControl = true;
        public bool CanBeKilled => SanityVal == 0;

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
            if (HoldingItem != null)
            {
                item.Discard();
                HoldingItem = null;
            }
        }

        public void TakeDamage(float damage)
        {
            Console.WriteLine($"Player took {damage} damage");

            if (CanBeKilled)
            {
                Console.WriteLine($"Player {Name} died!");
            }
            else
            {
                if (StaminaVal != 0)
                {
                    StaminaVal = StaminaVal - damage;
                    if (StaminaVal < 0)
                    {
                        SanityVal = SanityVal - Math.Abs(StaminaVal);
                        StaminaVal = 0;
                    }
                }
                else if (SanityVal != 0)
                {
                    SanityVal = SanityVal - damage;
                    if (SanityVal < 0)
                    {
                        SanityVal = 0;
                    }
                }
            }

        }

        public void Draw()
        {
            Console.WriteLine($"Name : {Name}, HoldingItem : {HoldingItem}, Stamina : {StaminaVal}, Sanity : {SanityVal}");
        }
    }
}
