using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAI : MonoBehaviour{
    private Transform player;
    
    public float moveSpeed = 5f;
    public float roamRange = 30f;
    public float attackRate = 0.3f;
    
    private Transform startingPosition;
    private Vector3 startingPos;
    private float initialScale;
    private bool isAttacking = false;
    private float nextAttackTime;
    private Animator anim;

    
    void Start(){
        player = GameObject.Find("Player").transform;

        startingPosition = transform;
        startingPos = transform.position;
        initialScale = transform.localScale.x;
        anim = GetComponent<Animator>();
    }

    void Update(){
        float roamDistance = Vector3.Distance(player.position, startingPos);
        float travelDistance = Vector3.Distance(transform.position, startingPos);
        
        if (roamDistance <= roamRange){     
            Rotate(player);       
            if(!isAttacking){     
                anim.SetBool("inAttackRange", false);
                anim.SetBool("isRunning", true);        
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }
        else{
            if (travelDistance != 0){
                Rotate(startingPosition);
                anim.SetBool("isRunning", true);
                anim.SetBool("inAttackRange", false);
                transform.position = Vector3.MoveTowards(transform.position, startingPos, moveSpeed * Time.deltaTime);
            }
            else {
                anim.SetBool("isRunning", false);
                anim.SetBool("inAttackRange", false);
            }
        }
    }

    void Rotate(Transform destination){
        Vector3 direction = destination.position - transform.position;
        if (direction.x >= 0){
            transform.localScale = new Vector2(initialScale, transform.localScale.y);
        }
        else {
            transform.localScale = new Vector2(-initialScale, transform.localScale.y);
        }
    }

    void OnCollisionStay2D(Collision2D other){
        if (other.gameObject.name == "Player"){
            Debug.Log("touching");
            isAttacking = true;
            anim.SetBool("inAttackRange", true);
            anim.SetBool("isRunning", false);   
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.name == "Player"){
            Debug.Log("no touching");
            isAttacking = false;
            anim.SetBool("inAttackRange", false);
            anim.SetBool("isRunning", true);   
        }
    }
}
