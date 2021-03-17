// Copyright (c) Team STEP.  All Rights Reserved.

using System;
using CatchIoScriptImpl.Items;

namespace CatchIoScriptImpl.PlayerCharacter
{
    public class Player
    {
        public string Name { get; private set; } = "Test Player";
        public string CharSkin { get; private set; } = "Druid_A";
#nullable enable
        public Item? HoldingItem;
#nullable disable
        public float StaminaVal = 0;
        public float SanityVal = 10;
        public bool CanControl = true;

        // temporary logic
        public bool CanBeKilled => SanityVal == 0;
        public float MeleeDamage { get; private set; } = 4f;

        public Action<Item> AddItemToInventoryAction;
        public Action RemoveHoldingItemAction;

        public void Attack(IDamageable other)
        {
            other.OnDamage(MeleeDamage);
        }

        public void ThrowItem(ThrowableItem item)
        {
            item.OnThrow((1f, 1f), (5f, 5f));
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
            item.OnPickup();
            AddItemToInventoryAction(item);
        }

        public void DiscardItem()
        {
            if (HoldingItem != null)
            {
                HoldingItem.OnDiscard();
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
