// Copyright (c) Team STEP.  All Rights Reserved.

using System;
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
            if (!_player.CanControl)
                return;

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
                    _player.ThrowItem(ti, (4f, 4f));
                    break;
                case ConsumableItem ci:
                    _player.ConsumeItem(ci);
                    break;
                default:
                    break;
            }
        }

        public (float, float)[] CalculateTrajectory(float timeToTarget, (float, float, float) initalVelocity)
        {
            return new (float, float)[0];
        }

        public void RenderAimTrajectory((float, float)[] throwPath)
        {
            Console.WriteLine($"Throwing to {throwPath}");
        }

        /// <summary>
        /// Test method to trigger the Use Item command
        /// </summary>
        /// <returns></returns>
        private bool OnClickedUseItem()
        {
            return true;
        }

    }
}
