using System;
using System.Collections.Generic;
using System.Text;
using CatchIoScriptImpl.Helpers;

namespace CatchIoScriptImpl.PlayerCharacter
{
    class InventoryController
    {
        private readonly Player _player;
        public Inventory Inventory { get; private set; }
        public int CurrentIndex { get; private set; }

        public InventoryController(Player owner)
        {
            _player = owner;
            Inventory = new Inventory();

            _player.AddItemToInventoryAction += Inventory.AddItem;
            _player.RemoveHoldingItemAction += RemoveCurrentItem;
        }

        /// <summary>
        /// Unity update function (runs every frame)
        /// </summary>
        public void Update()
        {
            // listen to user input
            int inputVal = UserInputHelper.GetItemSelectInput();
            SelectItem(inputVal);
        }

        public void SelectItem(int inputInvIndex)
        {
            _player.holdingItem = Inventory.GetItem(inputInvIndex);
            CurrentIndex = inputInvIndex;
            Console.WriteLine("Changed player's current item");
        }

        private void RemoveCurrentItem()
        {
            Inventory.RemoveItem(CurrentIndex);
            _player.holdingItem = null;
        }

        public void Draw()
        {
            Inventory.Draw();
        }
    }
}
