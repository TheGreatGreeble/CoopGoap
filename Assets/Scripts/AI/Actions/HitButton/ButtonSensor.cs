using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using UnityEngine;

public class ButtonSensor : LocalTargetSensorBase
{
    public PuzzleConfig puzzle;
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
        Vector2 buttonPos = this.GetNextButton();
        
        return new PositionTarget(buttonPos);
    }

    private Vector2 GetNextButton()
    {
        // Find the player GameObject by tag
        GameObject player = GameObject.FindWithTag("Player");
        
        foreach (var ele in puzzle.Sequence){
            bool eleCompleted = ele.GetComponent<FloorButton>().isActive;
            if (!eleCompleted) {
                return ele.transform.position;
            }
        }
        return Vector2.zero; // maybe replace with some kind of error log, this shouldn't run if puzzle is solved.
    }
}