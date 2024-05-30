using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using UnityEngine;

public class StopAction : ActionBase<StopAction.Data>
{
    // Called when the class is created.
    public override void Created()
    {
    }

    // Called when the action is started for a specific agent.
    public override void Start(IMonoAgent agent, Data data)
    {
        // When the agent is at the target, wait an amount of time before moving again.
        data.Timer = 5f;
    }

    // Called each frame when the action needs to be performed. It is only called when the agent is in range of it's target.
    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        // Update timer.
        data.Timer -= context.DeltaTime;
        
        // If the timer is still higher than 0, continue next frame.
        if (data.Timer > 0)
            return ActionRunState.Continue;
        
        // This action is done, return stop. This will trigger the resolver for a new action.
        return ActionRunState.Stop;
    }

    // Called when the action is ended for a specific agent.
    public override void End(IMonoAgent agent, Data data)
    {
    }

    public class Data : IActionData
    {
        public ITarget Target { get; set; }
        public float Timer { get; set; }
    }
}
