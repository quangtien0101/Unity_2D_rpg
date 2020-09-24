using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAI : MonoBehaviour{
    public Transform player;
    public float moveSpeed = 5f;
    public float roamRange = 30f;
    public float attackRange = 3f;
    public float attackRate = 0.3f;
    
    private Vector3 startingPosition;
    private float initialScale;
    private float nextAttackTime;
    private Animator anim;

    
    void Start(){
        startingPosition = transform.position;
        anim = GetComponent<Animator>();
        initialScale = transform.localScale.x;

    }

    void Update(){
        float roamDistance = Vector3.Distance(player.position, startingPosition);
        float distance = Vector3.Distance(transform.position, player.position);
        Vector3 direction = player.position - transform.position;
        anim.SetBool("inAttackRange", false);
        anim.SetBool("isRunning", false);

        if (direction.x >= 0){
            transform.localScale = new Vector2(initialScale, transform.localScale.y);
        }
        else {
            transform.localScale = new Vector2(-initialScale, transform.localScale.y);
        }

        if (roamDistance <= roamRange){     
            anim.SetBool("isRunning", true);  
            if (distance <= attackRange){
                anim.SetBool("inAttackRange", true);
            }
            else{
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }
        else{
            anim.SetBool("isRunning", true);
            transform.position = Vector3.MoveTowards(transform.position, startingPosition, moveSpeed * Time.deltaTime);
            anim.SetBool("isRunning", false);
        }

    }
}
