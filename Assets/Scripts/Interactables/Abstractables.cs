using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private protected List<Reciever> recievers = new List<Reciever>();
    public abstract void Interact();
    private protected void SendInteract(){
        foreach(Reciever recv in recievers){
            recv.RecieveInteract();
        }
    }
}

public abstract class Reciever : MonoBehaviour
{
    public abstract void RecieveInteract();
}