using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{   public static int level = 1;
    public static int nextLevel;
    public static int xp = 0;
    public static int xpToLevel;
    public static int xpDiff;
    public static int life;
    public static int totalLife;
    public static int magic;
    public static int totalMagic;
    public static int attack;
    public static int defense;
    private bool blinkActive;
    public float blinckTime;
    private float blinckCounter;
    public SkinnedMeshRenderer playerRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
     Recalculation();   
    }

    // Update is called once per frame
    void Update()
    {
        nextLevel = level + 1;
        xpToLevel = 50 * nextLevel * level;

        if(xp >= xpToLevel){
            xpDiff = xp - xpToLevel;
            levelUP();
        }    

        if(life <= 0){
            life = 0;
        }

        if(magic <= 0){
            magic = 0;
        }

        attack = 5 * level;
        defense = 3 * level;

        /*
        
        Debug sliders

        if(Input.GetKeyDown(KeyCode.Q)){
            addXp (125);
        }
        if(Input.GetKeyDown(KeyCode.Z)){
            life -= 10;
        }
         if(Input.GetKeyDown(KeyCode.X)){
            magic -= 10;
        }
        */
        activeBlink();

    }
    public void Recalculation(){
        totalLife  = 25 * level;
        totalMagic = 10 * level;
        life       = totalLife;
        magic      =totalMagic;
    }
    public static void addXp (int newXp){
        xp+= newXp;
    }
    public void levelUP(){
        level++;
        xp = 0 + xpDiff;
        Recalculation();
    }
    public void DemageReceived(int damage){
        life -= damage;
        blinkActive =  true;
        blinckCounter = blinckTime;
        if(life <= 0){
            Debug.Log("morto");
        }
    }
    public void activeBlink(){
        if(blinkActive == true){
            if(blinckCounter > blinckTime * 0.66f){
                playerRenderer.enabled = false;
            } else if (blinckCounter > blinckTime * 0.33f){
                playerRenderer.enabled = true;                
            } else if (blinckCounter > 0){
                playerRenderer.enabled = false;
            } else {
                playerRenderer.enabled = true;
                blinkActive = false;
            }

            blinckCounter -= Time.deltaTime;

        }

    }
}
