// Copyright (c) Team STEP.  All Rights Reserved.

using CatchIoScriptImpl.Items;

namespace CatchIoScriptImpl.PlayerCharacter
{
    public class PlayerController
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
                switch (_player.HoldingItem)
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
