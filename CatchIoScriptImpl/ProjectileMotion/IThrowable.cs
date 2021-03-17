// Copyright (c) Team STEP.  All Rights Reserved.

namespace CatchIoScriptImpl.ProjectileMotion
{
    public interface IThrowable
    {
        bool IsOnFloor { get; }

        void OnLanded((float, float) landPos);

        void OnThrow((float, float) throwPos, (float, float) targetPos);

        TrajectoryArc CalculateTrajectory((float, float) throwPos, (float, float) targetPos);

    }
}
