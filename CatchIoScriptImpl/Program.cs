// Copyright (c) Team STEP.  All Rights Reserved.

using System;
using CatchIoScriptImpl.Items;
using CatchIoScriptImpl.PlayerCharacter;

namespace CatchIoScriptImpl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting game...");
            Player player = new Player();
            PlayerController playerController = new PlayerController(player);
            PlayerHitbox hitbox = new PlayerHitbox(player);
            InventoryController inventoryController = new InventoryController(player);

            inventoryController.Inventory.AddItem(new Stone());
            inventoryController.Inventory.AddItem(new StaminaPotion());
            inventoryController.Draw();
            player.Draw();

            inventoryController.Update();
            player.Draw();
            playerController.Update();
            player.Draw();
            inventoryController.Draw();

            Stone randomStone = new Stone();

            player.PickupItem(randomStone);
            inventoryController.Draw();

            hitbox.OnTriggerEnter(new Stone());
            inventoryController.SelectItem(2);
            player.Draw();
        }
    }
}
