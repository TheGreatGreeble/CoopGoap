using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using UnityEngine;

public class WaitTargetSensor : LocalTargetSensorBase
{
    public PuzzleConfig puzzle;
    // Called when the class is created.
    public override void Created()
    {
        puzzle = GameObject.FindWithTag("PuzzleConfig").GetComponent<PuzzleConfig>();
    }

    // Called each frame. This can be used to gather data from the world before the sense method is called.
    // This can be used to gather 'base data' that is the same for all agents, and otherwise would be performed multiple times during the Sense method.
    public override void Update()
    {
    }

    // Called when the sensor needs to sense a target for a specific agent.
    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
        if (puzzle.GetNextButton() == null) return new PositionTarget(agent.transform.position);
        return new PositionTarget(puzzle.GetNextAlienButton().transform.position);
    }
}