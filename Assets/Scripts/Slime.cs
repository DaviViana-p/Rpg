using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public int agroRange = 10;
    public GameObject target;
    public Rigidbody rb;
    private bool isMove;
    private Vector3 moveDirection;
    public float waitTime;
    public float waitCounter;
    public float moveTime;
    private float moveCounter;
    public Animator animator;
    // Start is called before the first frame update
    void Awake(){
        rb = GetComponent<Rigidbody> ();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");


        RandomWaitCounter();
        randomMoveCounter();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt (target.transform.position);
        if(Vector3.Distance(target.transform.position, transform.position )> agroRange){
           
            if(isMove){
                moveCounter -=Time.deltaTime;
                rb.velocity = moveDirection;
                
                if(moveCounter <0.0f){
                    isMove = false;
                    RandomWaitCounter();
                }
            }
            
            else{
            waitCounter -= Time.deltaTime;
            rb.velocity = Vector3.zero;

            if(waitCounter < 0.0f){
                isMove = true;
                randomMoveCounter();
                moveDirection = new Vector3(Random.Range (-1.0f, 1.0f )* moveSpeed, 0.0f, Random.Range(-1.0f, 1.0f));
           }
        }
     }
        if(Vector3.Distance(target.transform.position, transform.position) <= agroRange){
            Vector3 dir = target.transform.position - transform.position;
            dir.Normalize();
            transform.position += dir * moveSpeed * Time.deltaTime;
            animator.SetTrigger("Move");
        }
        /*if(EnemyStatus.morto == true){
            AnimDeath();
        }
        if(EnemyStatus.Damage == true){
            AnimDamage();
        }*/
    }
    public void RandomWaitCounter(){
        waitCounter = Random.Range(waitTime*0.75f, waitTime*1.25f);
        animator.SetTrigger("Idle");
        
    }
    private void randomMoveCounter(){
        moveCounter = Random.Range(moveTime*0.75f, moveTime*1.25f);
        animator.SetTrigger("Move");
    }   
   /*public void AnimDamage(){
        animator.SetTrigger("Damage");
    } 
    private void AnimDeath(){
        animator.SetTrigger("Death");
    }    */    
}
