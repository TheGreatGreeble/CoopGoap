using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlienAnimation : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private SpriteRenderer sprite;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(navAgent.velocity.x < 0){
            sprite.flipX = true;
        }
        else if(navAgent.velocity.x > 0){
            sprite.flipX = false;
        }
        
        if(Mathf.Abs(navAgent.velocity.x) > 0 || Mathf.Abs(navAgent.velocity.y) > 0){
            animator.SetBool("walking", true);
        }
        else{
            animator.SetBool("walking", false);
        }
    }
}
