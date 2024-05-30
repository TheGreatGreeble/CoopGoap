using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Configs.Interfaces;
using CrashKonijn.Goap.Resolver;
using CrashKonijn.Goap.Enums;

public class GoapSetConfigFactory : GoapSetFactoryBase
{
    public override IGoapSetConfig Create()
    {
        var builder = new GoapSetBuilder("GettingStartedSet");
        
        // Goals
        builder.AddGoal<WanderGoal>()
            .AddCondition<IsWandering>(Comparison.GreaterThanOrEqual, 1);
        builder.AddGoal<FollowGoal>()
            .AddCondition<IsFollowing>(Comparison.GreaterThanOrEqual, 1);
        builder.AddGoal<StopGoal>()
            .AddCondition<IsStopping>(Comparison.GreaterThanOrEqual, 1);

        // Actions
        builder.AddAction<WanderAction>()
            .SetTarget<WanderTarget>()
            .AddEffect<IsWandering>(EffectType.Increase)
            .SetBaseCost(1)
            .SetInRange(0.3f);
        builder.AddAction<FollowAction>()
            .SetTarget<FollowTarget>()
            .AddEffect<IsFollowing>(EffectType.Increase)
            .SetBaseCost(1)
            .SetInRange(0.3f);
        builder.AddAction<StopAction>()
            .SetTarget<StopTarget>()
            .AddEffect<IsStopping>(EffectType.Increase)
            .SetBaseCost(1)
            .SetInRange(0.3f);

        // Target Sensors
        builder.AddTargetSensor<WanderTargetSensor>()
            .SetTarget<WanderTarget>();
        builder.AddTargetSensor<FollowTargetSensor>()
            .SetTarget<FollowTarget>();
        builder.AddTargetSensor<StopTargetSensor>()
            .SetTarget<StopTarget>();

        // World Sensors
        // This example doesn't have any world sensors. Look in the examples for more information on how to use them.

        return builder.Build();
    }
}