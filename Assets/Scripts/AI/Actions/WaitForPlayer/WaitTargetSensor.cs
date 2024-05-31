using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using UnityEngine;

public class WaitTargetSensor : LocalTargetSensorBase
{
    // Called when the class is created.
    public override void Created()
    {
    }

    // Called each frame. This can be used to gather data from the world before the sense method is called.
    // This can be used to gather 'base data' that is the same for all agents, and otherwise would be performed multiple times during the Sense method.
    public override void Update()
    {
    }

    // Called when the sensor needs to sense a target for a specific agent.
    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
        Vector3 playerPos = this.GetPlayerPosition();
        
        return new PositionTarget(playerPos);
    }

    private Vector3 GetPlayerPosition()
    {
        // Find the player GameObject by tag
        GameObject player = GameObject.FindWithTag("Player");
        
        // Check if the player GameObject is found
        if (player != null)
        {
            // Return the player's position
            return player.transform.position;
        }
        else
        {
            // Handle the case where the player GameObject is not found
            Debug.LogWarning("Player GameObject not found!");
            return Vector3.zero; // Return a default value or handle appropriately
        }
    }
}