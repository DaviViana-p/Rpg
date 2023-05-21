using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemageOnPlayer : MonoBehaviour
{
    public int damage;
    public bool inAtaque;
    private float atkCounter;
    public float atkTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        inAtaque = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player" && inAtaque == false){
            inAtaque = true;
            damage = gameObject.GetComponent<EnemyStatus>().Ataque - PlayerStatus.defense;
            other.gameObject.GetComponent<PlayerStatus>().DemageReceived(damage);
            inAtaque = false;
        }
    }
    public void  OnTriggerStay(Collider other){
        if(other.gameObject.tag =="Player"){
            atkCounter += Time.deltaTime;
            if(atkCounter > atkTime){
                transform.Translate(Vector3.back);
                atkCounter = 0.0f;
            }
        }
    }
}
