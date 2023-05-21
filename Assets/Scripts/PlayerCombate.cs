using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombate : MonoBehaviour
{
    public static bool attacking;
    public float atkTime = 0.5f;
    private float atkCounter;
    public Animator playerAnimator;
    public GameObject Weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!attacking){
            Weapon.GetComponent<BoxCollider> ().enabled = false;

            if(Input.GetKeyDown (KeyCode.Mouse0)){
                atkCounter = atkTime;
                attacking = true;
                Weapon.GetComponent<BoxCollider> ().enabled = true; 
                playerAnimator.SetBool ("Ataque", true);             
            }
        }
        if(atkCounter > 0){
            atkCounter -= Time.deltaTime;
        }
        if(atkCounter <= 0){
            attacking = false;
            playerAnimator.SetBool ("Ataque", false);
        }

    }
}