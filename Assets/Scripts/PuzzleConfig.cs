using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleConfig : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> Sequence;

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
}
