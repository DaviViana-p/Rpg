using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsWindow : MonoBehaviour
{
    public Text level;
    public Text Xp;
    public Text Magic;
    public Text Life;
    public Text Ataque;
    public Text Defesa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "level: " + PlayerStatus.level;
        Xp.text = "xp: " +PlayerStatus.xp + " / " + "Xp To Level: " + PlayerStatus.xpToLevel;
        Life.text = "life: " + PlayerStatus.life + " / " + PlayerStatus.totalLife;
        Magic.text = "Magic: " + PlayerStatus.magic + " / " + PlayerStatus.totalMagic;
        Ataque.text = "Ataque: " + PlayerStatus.attack;
        Defesa.text = "Defesa: " + PlayerStatus.defense; 
        
    }
}
