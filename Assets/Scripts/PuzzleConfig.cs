using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public GameObject GetNextButton()
    {
        // Find the player GameObject by tag
        GameObject player = GameObject.FindWithTag("Player");
        
        foreach (var ele in Sequence){
            bool eleCompleted = ele.GetComponent<FloorButton>().isActive;
            bool isPlayerButton = ele.name == "Pbutton" ? true : false;
            if (!eleCompleted) {
                return ele;
            }
        }
        return null; // maybe replace with some kind of error log, this shouldn't run if puzzle is solved.
    }
    public GameObject GetNextAlienButton()
    {
        // Find the player GameObject by tag
        GameObject player = GameObject.FindWithTag("Player");
        
        foreach (var ele in Sequence){
            bool eleCompleted = ele.GetComponent<FloorButton>().isActive;
            bool isPlayerButton = ele.name == "pButton" ? true : false;
            if (!eleCompleted && !isPlayerButton) {
                return ele;
            }
        }
        return null; // maybe replace with some kind of error log, this shouldn't run if puzzle is solved.
    }
    public GameObject GetNextPlayerButton()
    {
        // Find the player GameObject by tag
        GameObject player = GameObject.FindWithTag("Player");
        
        foreach (var ele in Sequence){
            bool eleCompleted = ele.GetComponent<FloorButton>().isActive;
            bool isPlayerButton = ele.name == "pButton" ? true : false;
            if (!eleCompleted && isPlayerButton) {
                return ele;
            }
        }
        return null; // maybe replace with some kind of error log, this shouldn't run if puzzle is solved.
    }
}
