using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAI : MonoBehaviour{
    public Transform player;
    public float moveSpeed = 5f;
    public float roamRange = 30f;
    public float attackRange = 3f;
    public float attackRate = 0.3f;
    
    private Transform startingPosition;
    private Vector3 startingPos;
    private float initialScale;
    private float nextAttackTime;
    private Animator anim;

    
    void Start(){
        startingPosition = transform;
        startingPos = transform.position;
        initialScale = transform.localScale.x;
        anim = GetComponent<Animator>();
    }

    void Update(){
        float roamDistance = Vector3.Distance(player.position, startingPos);
        float travelDistance = Vector3.Distance(transform.position, startingPos);
        float distance = Vector3.Distance(transform.position, player.position);

        anim.SetBool("inAttackRange", false);
        anim.SetBool("isRunning", false);
        if (roamDistance <= roamRange){     
            Rotate(player);
            anim.SetBool("isRunning", true);  
            if (distance <= attackRange){
                anim.SetBool("inAttackRange", true);
            }
            else{                
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }
        else{
            if (travelDistance != 0){
                Rotate(startingPosition);
                anim.SetBool("isRunning", true);
                transform.position = Vector3.MoveTowards(transform.position, startingPos, moveSpeed * Time.deltaTime);
            }
        }
    }

    void Rotate(Transform destination){
        Vector3 direction = destination.position - transform.position;
        Debug.Log(direction.x);
        if (direction.x >= 0){
            transform.localScale = new Vector2(initialScale, transform.localScale.y);
        }
        else {
            transform.localScale = new Vector2(-initialScale, transform.localScale.y);
        }
    }
}
