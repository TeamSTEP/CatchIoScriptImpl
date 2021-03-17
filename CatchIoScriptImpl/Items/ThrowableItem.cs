// Copyright (c) Team STEP.  All Rights Reserved.

using System;
using CatchIoScriptImpl.ProjectileMotion;

namespace CatchIoScriptImpl.Items
{
    public abstract class ThrowableItem : Item, IThrowable
    {
        // temporary value to represent the Rigidbody2D class in Unity
        public abstract string Rigidbody { get; }
        public abstract bool IsOnFloor { get; }

        public abstract TrajectoryArc CalculateTrajectory((float, float) throwPos, (float, float) targetPos);
        public abstract void OnLanded((float, float) landPos);
        public abstract void OnThrow((float, float) throwPos, (float, float) targetPos);

        public virtual void Throw()
        {
            Console.WriteLine("Throwing Item");
        }
    }
}
