using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaitForPlayerAction : ActionBase<WaitForPlayerAction.Data>
{
    PuzzleConfig puzzle;
    GameObject playerButton;
    GameObject alienButton;
    // Called when the class is created.
    public override void Created()
    {
        puzzle = GameObject.FindWithTag("PuzzleConfig").GetComponent<PuzzleConfig>();
        
    }

    // Called when the action is started for a specific agent.
    public override void Start(IMonoAgent agent, Data data)
    {
        // // When the agent is at the target, wait a random amount of time before moving again.
        playerButton = puzzle.GetNextPlayerButton();
        alienButton = puzzle.GetNextAlienButton();
        Debug.Log(alienButton.name);

    }

    // Called each frame when the action needs to be performed. It is only called when the agent is in range of it's target.
    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        List<Collider2D> overlaps = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        agent.GetComponent<BoxCollider2D>().OverlapCollider(filter.NoFilter(),overlaps);
        foreach(Collider2D col in overlaps){
            if (col.gameObject == alienButton) {
                Debug.Log("stoping waiting");
                if (puzzle.GetNextButton() == alienButton) {
                    Debug.Log("stoping waiting");
                    return ActionRunState.Stop;
                }
            }
        }
        
        // If the button isn't hit, keep going
        return ActionRunState.Continue;
        
    }

    // Called when the action is ended for a specific agent.
    public override void End(IMonoAgent agent, Data data)
    {
    }

    public class Data : IActionData
    {
        public ITarget Target { get; set; }
    }
}
