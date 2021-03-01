using System;
using CatchIoScriptImpl.Items;
using CatchIoScriptImpl.PlayerCharacter;

namespace CatchIoScriptImpl
{
    class Program
    {
        static void Main(string[] args)
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

            hitbox.OnTriggerEnter(new Stone());
            player.Draw();
        }
    }
}
