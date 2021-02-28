using System;
using CatchIoScriptImpl.Models;
using CatchIoScriptImpl.Interfaces;

namespace CatchIoScriptImpl
{
    class Stone : OffensiveThrowableItem
    {
        private readonly float _damageVal = 5;
        public override float DamageVal { get { return _damageVal; } }

        public override void Throw()
        {
            Console.WriteLine("Throwing stone");
        }
    }

    class StaminaPotion : ConsumableItem
    {
        public override void Consume()
        {
            Console.WriteLine("Consuming Stamina Potion");
        }
    }

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

    class Player
    {
        public string name;
        public string charSkin;
#nullable enable
        public Item? holdingItem;
#nullable disable
        public float staminaVal = 0;
        public float sanityVal = 0;
        public bool canControl;
        public bool CanBekilled
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
            item.Consume();
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
            if (CanBekilled)
            {
                Console.WriteLine($"Player {name} died!");
            }
            else
            {
                Console.WriteLine($"Player took {damage} damage");
            }

        }
    }

    class PlayerController
    {
        private readonly Player _player;

        public PlayerController(Player owner)
        {
            _player = owner;
        }

        public void Update()
        {
            if (OnClickedUseItem())
            {
                switch (_player.holdingItem)
                {
                    case ThrowableItem item:
                        _player.ThrowItem(item);
                        break;
                    case ConsumableItem item:
                        _player.ConsumeItem(item);
                        break;
                    default:
                        break;
                }
            }
        }

        private bool OnClickedUseItem()
        {
            return true;
        }

    }

    class InventoryController
    {
        private readonly Player _player;
        public Inventory Inv { get; private set; }
        public int CurrentIndex { get; private set; }

        public InventoryController(Player owner)
        {
            _player = owner;
            Inv = new Inventory();

            _player.AddItemToInventoryAction += Inv.AddItem;
            _player.RemoveHoldingItemAction += RemoveCurrentItem;
        }

        /// <summary>
        /// Unity update function (runs every frame)
        /// </summary>
        public void Update()
        {
            // on keyboard down
            int inputVal = GetInvInputIndex();
            SelectItem(inputVal);
        }

        public void SelectItem(int inputInvIndex)
        {
            _player.holdingItem = Inv.GetItem(inputInvIndex);
            CurrentIndex = inputInvIndex;
            Console.WriteLine("Changed player's current item");
        }

        private void RemoveCurrentItem()
        {
            Inv.RemoveItem(CurrentIndex);
            _player.holdingItem = null;
        }

        public void Draw()
        {
            Inv.Draw();
        }

        /// <summary>
        /// Test method for simulating user input
        /// </summary>
        /// <returns></returns>
        private int GetInvInputIndex()
        {
            // listen to inventory key down event
            int inputIndex = 1;
            return inputIndex;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Player player = new Player();
            PlayerController playerController = new PlayerController(player);
            PlayerHitbox hitbox = new PlayerHitbox(player);
            InventoryController inventoryController = new InventoryController(player);

            inventoryController.Inv.AddItem(new Stone());
            inventoryController.Inv.AddItem(new StaminaPotion());
            inventoryController.Draw();

            inventoryController.Update();
            playerController.Update();
            inventoryController.Draw();

            hitbox.OnTriggerEnter(new Stone());
        }
    }
}
