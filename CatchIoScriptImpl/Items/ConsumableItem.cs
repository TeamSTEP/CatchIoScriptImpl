using System;
using System.Collections.Generic;
using System.Text;
using CatchIoScriptImpl.PlayerCharacter;

namespace CatchIoScriptImpl.Items
{
    abstract class ConsumableItem : Item
    {
        public abstract void Consume(Player consumer);
    }
}
