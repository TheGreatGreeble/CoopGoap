using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class AgentBrain : MonoBehaviour
{
    private AgentBehaviour agent;
    private PlayerInput input;
    private InputAction instruction;
    private bool shouldSolvePuzzle = false;

    private void Awake()
    {
        this.agent = this.GetComponent<AgentBehaviour>();
        input = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
        instruction = input.actions.FindAction("Instruct");
    }

    private void Start()
    {
        //this.agent.SetGoal<WanderGoal>(false);
        //this.agent.SetGoal<FollowGoal>(false);
        agent.SetGoal<FollowGoal>(true);
        //agent.SetGoal<PuzzleGoal>(true);
    }

    private void Update() {
        // Check for the "E" key press every frame
        if (instruction.triggered)
        {
            if (!shouldSolvePuzzle) {
                agent.EndAction();
                agent.SetGoal<PuzzleGoal>(false);
                shouldSolvePuzzle = true;
            } else {
                agent.EndAction();
                agent.SetGoal<FollowGoal>(false);
            }
            
            
            
        }
    }
    //FixedUpdate is where we inject goals to the ai through player action
    void FixedUpdate()
    {
        
        // // Check the distance from the player and set the goals accordingly
        // if (DistanceFromPlayer() >= 5)
        // {
        //     //agent.SetGoal<StopGoal>(true);;
        //     agent.SetGoal<PuzzleGoal>(true);
        // }
        // else
        // {
        //     agent.SetGoal<StopGoal>(false);;
        //     agent.SetGoal<FollowGoal>(true);
        // }
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