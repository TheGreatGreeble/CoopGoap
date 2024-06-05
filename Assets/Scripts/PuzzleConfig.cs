using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleConfig : Reciever
{
    [SerializeField]
    public List<GameObject> Sequence;
    private bool SequenceComplete = false;
    [SerializeField] private Reciever reciever;

    private void Start() {
        if (Sequence == null || Sequence.Count == 0){
            Debug.LogError("NO PUZZLE SEQUENCE FOUND IN" + gameObject.name);
        }
    }

    public void insertButton(GameObject button) {
        if (!Sequence.Contains(button)) {
            Sequence.Add(button);
        }
    }

    public void clearSequence() {
        if (Sequence != null)
        {
            Sequence.Clear();
            Debug.Log("PuzzleConfig Sequence list has been cleared.");
        }
    }
    
    public override void RecieveInteract(){
        SequenceComplete = true;
        foreach(GameObject button in Sequence){
            SequenceComplete = SequenceComplete && button.GetComponent<FloorButton>().isActive;
        }
        if(SequenceComplete){
            reciever.RecieveInteract();
        }
    }
}
