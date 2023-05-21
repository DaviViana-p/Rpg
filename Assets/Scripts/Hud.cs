using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{   
    public Text LevelText;
    public Slider LifeSlider;
    public Slider MagicSlider;
    public Slider xpSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelText.text = PlayerStatus.level.ToString();
        
        LifeSlider.maxValue = PlayerStatus.totalLife;
        LifeSlider.value = PlayerStatus.life;
        MagicSlider.maxValue = PlayerStatus.totalMagic;
        MagicSlider.value = PlayerStatus.magic;
        xpSlider.maxValue = PlayerStatus.xpToLevel;
        xpSlider.value = PlayerStatus.xp;
        
    }
}
