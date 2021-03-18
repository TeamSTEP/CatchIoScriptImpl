// Copyright (c) Team STEP.  All Rights Reserved.

using System;
using CatchIoScriptImpl.Helpers;

namespace CatchIoScriptImpl.PlayerCharacter
{
    public class InventoryController
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
            if (!_player.CanControl)
                return;
            // listen to user input
            int inputVal = UserInputHelper.GetItemSelectInput();
            SelectItem(inputVal);
        }

        public void SelectItem(int inputInvIndex)
        {
            _player.HoldingItem = Inventory.GetItem(inputInvIndex);
            CurrentIndex = inputInvIndex;
            Console.WriteLine("Changed player's current item");
        }

        private void RemoveCurrentItem()
        {
            Inventory.RemoveItem(CurrentIndex);
            _player.HoldingItem = null;
        }

        public void Draw()
        {
            Inventory.Draw();
        }
    }
}
