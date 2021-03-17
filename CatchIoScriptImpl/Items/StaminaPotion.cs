// Copyright (c) Team STEP.  All Rights Reserved.

using System;
using CatchIoScriptImpl.PlayerCharacter;

namespace CatchIoScriptImpl.Items
{
    public class StaminaPotion : ConsumableItem
    {
        public float HealVal = 5f;

        public override void Consume(Player consumer)
        {

            Console.WriteLine("Consuming Stamina Potion");
            consumer.StaminaVal += HealVal;
        }
    }
}
