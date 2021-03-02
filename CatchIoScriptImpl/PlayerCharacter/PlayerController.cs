using System;
using System.Collections.Generic;
using System.Text;
using CatchIoScriptImpl.Items;

namespace CatchIoScriptImpl.PlayerCharacter
{
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
}
