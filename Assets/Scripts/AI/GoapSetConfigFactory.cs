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
        builder.AddGoal<PuzzleGoal>()
            .AddCondition<PuzzleCompleted>(Comparison.GreaterThanOrEqual, 10);
        builder.AddGoal<WanderGoal>()
            .AddCondition<IsWandering>(Comparison.GreaterThanOrEqual, 1);
        builder.AddGoal<FollowGoal>()
            .AddCondition<IsFollowing>(Comparison.GreaterThanOrEqual, 1);
        builder.AddGoal<StopGoal>()
            .AddCondition<IsStopping>(Comparison.GreaterThanOrEqual, 1);
        

        // Actions
        builder.AddAction<ButtonAction>()
            .SetTarget<ButtonTarget>()
            .AddEffect<PuzzleCompleted>(EffectType.Increase)
            .SetBaseCost(1)
            .SetInRange(0.2f);
        builder.AddAction<WanderAction>()
            .SetTarget<WanderTarget>()
            .AddEffect<IsWandering>(EffectType.Increase)
            .SetBaseCost(2)
            .SetInRange(0.3f);
        builder.AddAction<FollowAction>()
            .SetTarget<FollowTarget>()
            .AddEffect<IsFollowing>(EffectType.Increase)
            .SetBaseCost(2)
            .SetInRange(1.5f);
        builder.AddAction<StopAction>()
            .SetTarget<StopTarget>()
            .AddEffect<IsStopping>(EffectType.Increase)
            .SetBaseCost(2)
            .SetInRange(0.3f);
        
        

        // Target Sensors
        builder.AddTargetSensor<WanderTargetSensor>()
            .SetTarget<WanderTarget>();
        builder.AddTargetSensor<FollowTargetSensor>()
            .SetTarget<FollowTarget>();
        builder.AddTargetSensor<StopTargetSensor>()
            .SetTarget<StopTarget>();
        builder.AddTargetSensor<WaitTargetSensor>()
            .SetTarget<WaitTarget>();
        builder.AddTargetSensor<ButtonSensor>()
            .SetTarget<ButtonTarget>();

        // World Sensors

        builder.AddWorldSensor<PuzzleSensor>()
            .SetKey<PuzzleCompleted>();

        return builder.Build();
    }
}