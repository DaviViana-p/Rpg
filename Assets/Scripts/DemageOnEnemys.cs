using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemageOnEnemys : MonoBehaviour
{
    public int AtkBonus = 1;
    public int Damage;
    public bool inAtk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerCombate.attacking == false){
            inAtk = false;            
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Enemy" && inAtk == false){           
            Damage = AtkBonus + PlayerStatus.attack - other.gameObject.GetComponent<EnemyStatus>().Defesa;
            other.gameObject.GetComponent<EnemyStatus>().DemageReceived (Damage);
            inAtk = true;
        }
    }
}
