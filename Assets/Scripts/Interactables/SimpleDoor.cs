using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavMeshPlus.Components;

public class SimpleDoor : Reciever
{
    public bool isOpen = false;
    
    private Animator animator;
    
    private void Start() {
        animator = GetComponent<Animator>();
        animator.SetBool("Open", isOpen);
    }
    
    public override void RecieveInteract(){
        isOpen = !isOpen;
        animator.SetBool("Open", isOpen);
        StartCoroutine(UpdateNavmesh(animator.GetCurrentAnimatorStateInfo(0).length));
    }
    
    IEnumerator UpdateNavmesh(float waitTime){
        yield return new WaitForSeconds(waitTime);
        NavMeshSurface.activeSurfaces[0].BuildNavMesh();
    }
}