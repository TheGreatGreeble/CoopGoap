using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Sensors;
public class AlienButtonSensor : GlobalWorldSensorBase
{
    public PuzzleConfig puzzle;
    public override void Created()
    {
        puzzle = GameObject.FindWithTag("PuzzleConfig").GetComponent<PuzzleConfig>();
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

        GameObject nextButton = puzzle.GetNextButton();
        if (nextButton == null) return -1;
        if (!nextButton.GetComponent<FloorButton>().isHuman) {
            return 1;
        } else {
            return 0;
        }
    }
}
