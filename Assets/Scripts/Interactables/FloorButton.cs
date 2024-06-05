using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : Interactable
{
    public bool isHuman = true;
    public bool isActive = false;

    [SerializeField] bool oneTime = false;
    [SerializeField] bool waitActive = false;
    [SerializeField] float activeSeconds = 3f;
    
    [SerializeField] SpriteRenderer child;
    [SerializeField] private Sprite human;
    [SerializeField] private Sprite alien;
    
    [SerializeField] Color onColor = Color.green;
    [SerializeField] Color offColor = Color.red;
    
    private SpriteRenderer sprite;
    
    private void Start() {
        changeSpecies(isHuman);
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = isActive ? onColor : offColor;
        if(waitActive) oneTime = true;
        
    }
    
    
    public override void Interact(){
        if(!oneTime || (oneTime && !isActive)){
            isActive = !isActive;
            if(isActive){
                sprite.color = onColor;
            }
            else{
                sprite.color = offColor;
            }
            SendInteract();
            if(waitActive){
                StartCoroutine(WaitToDeactivate());
            }
        }
    }
    
    IEnumerator WaitToDeactivate(){
        yield return new WaitForSeconds(activeSeconds);
        isActive = !isActive;
        if(isActive){
            sprite.color = onColor;
        }
        else{
            sprite.color = offColor;
        }
    }

    public bool changeSpecies(bool Bool) {
        isHuman = Bool;
        if (isHuman) {
            child.sprite = human;
        }
        else {
            child.sprite = alien;
        }
        return Bool;
    }
}