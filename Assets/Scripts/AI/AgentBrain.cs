using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class AgentBrain : MonoBehaviour
{
    private bool currentlySolving = false;
    private AgentBehaviour agent;
    private PlayerInput input;
    private InputAction instruction;
    private bool shouldSolvePuzzle = false;
    private void OnEnable()
    {
        // enable input action(s)
        instruction.Enable();
    }

    private void Awake()
    {
        this.agent = this.GetComponent<AgentBehaviour>();

        input = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
        instruction = input.actions.FindAction("Instruct");
        instruction.performed += OnInstructionPerformed;
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
        // else
        // {
        //     agent.SetGoal<StopGoal>(false);;
        //     agent.SetGoal<FollowGoal>(true);
        // }
    }
    //FixedUpdate is where we inject goals to the ai through player action
    void FixedUpdate()
    {
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
            return 0; // Return
        }
    }

    private void OnInstructionPerformed(InputAction.CallbackContext context)
    {
        GameObject player = GameObject.FindWithTag("Player");

        Collider2D[] overlaps = new Collider2D[10];
        ContactFilter2D filter = new ContactFilter2D();
        BoxCollider2D boxCollider = player.GetComponent<BoxCollider2D>();
        int overlapCount = boxCollider.OverlapCollider(filter.NoFilter(), overlaps);

        //if the player is not standing on a button
        if (overlapCount == 0) {
            if (!currentlySolving) {
                currentlySolving = true;
                //set ai goal to solve puzzle
            }
            else {
                currentlySolving = false;
            }
        }
        //else if the player IS standing on a button
        else {
            foreach (var col in overlaps)
            {
                if (col != null)
                {
                    FloorButton floorButton = col.gameObject.GetComponent<FloorButton>();
                    if (floorButton != null) {
                        floorButton.changeSpecies(!floorButton.isHuman);
                    }
                }
            }
        }
    }
}