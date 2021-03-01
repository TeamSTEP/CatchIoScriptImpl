using System;
using System.Collections.Generic;
using System.Text;
using CatchIoScriptImpl.PlayerCharacter;

namespace CatchIoScriptImpl.Items
{
    class StaminaPotion : ConsumableItem
    {
        public float healVal = 5f;

        public override void Consume(Player consumer)
        {

            Console.WriteLine("Consuming Stamina Potion");
            consumer.staminaVal += healVal;
        }
    }
}
