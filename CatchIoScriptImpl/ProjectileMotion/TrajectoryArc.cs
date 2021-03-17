// Copyright (c) Team STEP.  All Rights Reserved.

namespace CatchIoScriptImpl.ProjectileMotion
{
    public struct TrajectoryArc
    {
        public (float, float, float) InitalVelocity;
        public float TimeToTarget;
        public (float, float, float)[] TrajectoryPath;

        public TrajectoryArc((float, float, float) initalVelocity, float timeToTarget, (float, float, float)[] trajectoryPath)
        {
            InitalVelocity = initalVelocity;
            TimeToTarget = timeToTarget;
            TrajectoryPath = trajectoryPath;
        }
    }
}
