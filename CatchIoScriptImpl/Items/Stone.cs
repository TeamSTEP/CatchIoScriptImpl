// Copyright (c) Team STEP.  All Rights Reserved.

using System;
using CatchIoScriptImpl.ProjectileMotion;

namespace CatchIoScriptImpl.Items
{
    public class Stone : OffensiveThrowableItem
    {
        private readonly float _damageVal = 13;
        public override float DamageVal => _damageVal;

        public override string Rigidbody => "Rigidbody2D Component";

        public override bool IsOnFloor => _hasLanded;

        private bool _hasLanded = false;

        public override void OnPickup()
        {
            Console.WriteLine("Picking Up Stone Item");
            base.OnPickup();
        }

        public override void OnDiscard()
        {
            Console.WriteLine("Discarding Stamina Potion");
            base.OnDiscard();
        }

        public override TrajectoryArc CalculateTrajectory((float, float) throwPos, (float, float) targetPos)
        {
            throw new NotImplementedException();
        }

        public override void OnLanded((float, float) landPos)
        {
            if (!_hasLanded)
            {
                _hasLanded = true;
            }
        }

        public override void OnBeforeThrow((float, float) throwPos, (float, float) targetPos)
        {
            Console.WriteLine($"Throwing Stone from {throwPos} to {targetPos}");
        }
    }
}
