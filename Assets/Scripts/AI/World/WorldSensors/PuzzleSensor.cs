using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Sensors;
public class PuzzleSensor : GlobalWorldSensorBase
{
    public PuzzleConfig puzzle;
    int puzzleSteps = 0; // number of steps until puzzle is completed
    public override void Created()
    {
        puzzle = GameObject.FindWithTag("PuzzleConfig").GetComponent<PuzzleConfig>();
        puzzleSteps = puzzle.Sequence.Count;
    }

    // public override void Update()
    // {
    // }

    // senses how much puzzle is left
    // 0 to Sequence.count == number in sequence that's next
    // -1 == unsolvable in current state
    public override SenseValue Sense()
    {
        // References are cached by the agent.
        // var hungerBehaviour = references.GetComponent<HungerBehaviour>();

        // if (hungerBehaviour == null)
        //     return false;

        bool incompleteFound = false;
        int numCompleted = 0;
        // return hungerBehaviour.hunger > 20;
        foreach (var ele in puzzle.Sequence){
            // TODO: Determine if sequence element not completed (== "Yes" is just temporary)
            bool eleCompleted = false; 
            if (ele.name == "Yes") {
                numCompleted++;
                eleCompleted = true;
            }

            if (!eleCompleted && !incompleteFound) {
                incompleteFound = true;
            } else if (eleCompleted && incompleteFound) {
                return -1;
            }
        }
        return numCompleted;
    }
}
