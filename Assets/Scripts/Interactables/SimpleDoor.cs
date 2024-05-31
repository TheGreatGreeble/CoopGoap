using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}