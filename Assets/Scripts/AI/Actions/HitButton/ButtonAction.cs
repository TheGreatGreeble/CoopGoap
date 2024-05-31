using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : ActionBase<ButtonAction.Data>
{
    // Called when the class is created.
    public override void Created()
    {
    }

    // Called when the action is started for a specific agent.
    public override void Start(IMonoAgent agent, Data data)
    {
        // // When the agent is at the target, wait a random amount of time before moving again.
        // data.Timer = Random.Range(0.3f, 1f);

    }

    // Called each frame when the action needs to be performed. It is only called when the agent is in range of it's target.
    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        List<GameObject> sequence = GameObject.FindWithTag("PuzzleConfig").GetComponent<PuzzleConfig>().Sequence;
        // Update timer.
        data.Timer -= context.DeltaTime;
        Collider2D[] overlaps = new Collider2D[50];
        ContactFilter2D filter = new ContactFilter2D();
        agent.GetComponent<BoxCollider2D>().OverlapCollider(filter.NoFilter(),overlaps);

        foreach (var col in overlaps){
            if (col == null) continue;
            if (sequence.Contains(col.gameObject)) {
                //TODO: proparly "press" the button
                col.gameObject.name = "Yes";
                return ActionRunState.Stop;
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
        public float Timer { get; set; }
    }
}
