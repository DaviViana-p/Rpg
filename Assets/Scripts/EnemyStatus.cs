using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int Ataque = 5;
    public int Defesa = 2;
    public int life = 20;
    public int xpGived = 10;
    public GameObject damageParticle;
    //public static bool morto;
    //public static bool Damage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Damage = false;
        //morto = false;
    }
    public void DemageReceived(int damage){
        life -= damage;
        Instantiate(damageParticle, transform.position, transform.rotation);
        //Damage = true;
        if(life <= 0){
            //morto = true;
            Destroy (gameObject);
            PlayerStatus.addXp(xpGived);
        }  
    }
}
