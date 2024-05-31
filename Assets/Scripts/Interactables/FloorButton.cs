using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : Interactable
{
    public bool isActive = false;
    public Color onColor = Color.green;
    public Color offColor = Color.red;
    
    [SerializeField] private List<Reciever> recievers = new List<Reciever>();
    
    private SpriteRenderer sprite;
    
    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = isActive ? onColor : offColor;
    }
    
    
    public override void Interact(){
        isActive = !isActive;
        if(isActive){
            sprite.color = onColor;
        }
        else{
            sprite.color = offColor;
        }
        foreach(Reciever recv in recievers){
            recv.RecieveInteract();
        }
    }
}