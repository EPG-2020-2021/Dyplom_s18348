using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsGUI : MonoBehaviour
{
    public static StatsGUI instance;

    public Slider healthSlider;
    public Slider armorSlider;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }



    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }
    public void SetArmor(float armor)
    {
        armorSlider.value = armor;
    }
   
}
