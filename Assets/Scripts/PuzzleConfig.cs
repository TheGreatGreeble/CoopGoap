using System.Collections;
using System.Collections.Generic;
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
}
