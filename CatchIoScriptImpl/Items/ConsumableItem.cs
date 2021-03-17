// Copyright (c) Team STEP.  All Rights Reserved.

using CatchIoScriptImpl.PlayerCharacter;

namespace CatchIoScriptImpl.Items
{
    public abstract class ConsumableItem : Item
    {
        public abstract void Consume(Player consumer);
    }
}
