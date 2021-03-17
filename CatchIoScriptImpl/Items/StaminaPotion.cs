// Copyright (c) Team STEP.  All Rights Reserved.

using System;
using CatchIoScriptImpl.PlayerCharacter;

namespace CatchIoScriptImpl.Items
{
    public class StaminaPotion : ConsumableItem
    {
        public float HealVal => _healVal;

        private readonly float _healVal = 5f;

        public override void Consume(Player consumer)
        {

            Console.WriteLine("Consuming Stamina Potion");
            consumer.StaminaVal += HealVal;
        }

        public override void OnPickup()
        {
            Console.WriteLine("Picking Up Stamina Potion");
        }

        public override void OnDiscard()
        {
            Console.WriteLine("Discarding Stamina Potion");
        }
    }
}
