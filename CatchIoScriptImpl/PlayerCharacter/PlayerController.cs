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
                UseItem(_player.HoldingItem);
            }
        }

        public void UseItem(Item item)
        {
            switch (item)
            {
                case ThrowableItem ti:
                    _player.ThrowItem(ti);
                    break;
                case ConsumableItem ci:
                    _player.ConsumeItem(ci);
                    break;
                default:
                    break;
            }
        }

        private bool OnClickedUseItem()
        {
            return true;
        }

    }
}
