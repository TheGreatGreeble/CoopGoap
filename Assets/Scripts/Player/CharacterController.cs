using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private PlayerInput input;
    private InputAction move;
    private InputAction interact;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        move = input.actions.FindAction("Move");
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        //disable rotation
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveWEDirection = move.ReadValue<Vector2>().x;
        float moveNSDirection = move.ReadValue<Vector2>().y;
        rb.velocity = new Vector2(moveWEDirection * moveSpeed, moveNSDirection * moveSpeed);
        
        if(Mathf.Abs(moveNSDirection) > 0 || Mathf.Abs(moveWEDirection) > 0){
            animator.SetBool("walking", true);
        }
        else{
            animator.SetBool("walking", false);
        }
        
        if(moveWEDirection < 0){
            sprite.flipX = true;
        }
        else if (moveWEDirection > 0){
            sprite.flipX = false;
        }
    }
    
    public void OnInteract() 
    {
        Collider2D[] overlaps = new Collider2D[50];
        ContactFilter2D filter = new ContactFilter2D();
        GetComponent<BoxCollider2D>().OverlapCollider(filter.NoFilter(),overlaps);

        foreach (var col in overlaps){
            if (col == null) continue;
            Interactable inter;
            if(col.TryGetComponent(out inter)){
                inter.Interact();
            }
        }
    }
}