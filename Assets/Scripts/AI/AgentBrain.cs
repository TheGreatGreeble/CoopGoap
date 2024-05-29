using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using UnityEngine;

public class AgentBrain : MonoBehaviour
{
    private AgentBehaviour agent;

    private void Awake()
    {
        this.agent = this.GetComponent<AgentBehaviour>();
    }

    private void Start()
    {
        //this.agent.SetGoal<WanderGoal>(false);
        this.agent.SetGoal<FollowGoal>(false);
    }

    //FixedUpdate is where we inject goals to the ai through player action
    private void FixedUpdate()
    {
        if (this.DistanceFromPlayer() >= 5) {
            this.agent.SetGoal<WanderGoal>(true);
        }
        else {
            this.agent.SetGoal<WanderGoal>(false);
            this.agent.SetGoal<FollowGoal>(true);
        }
    }

    private float DistanceFromPlayer()
    {
        // Find the player GameObject by tag
        GameObject player = GameObject.FindWithTag("Player");
        
        // Check if the player GameObject is found
        if (player != null)
        {
            // Return the player's position
            float distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
            return distanceToPlayer;
        }
        else
        {
            // Handle the case where the player GameObject is not found
            Debug.LogWarning("Player GameObject not found!");
            return 0; // Return a default value or handle appropriately
        }
    }

}