using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthController : MonoBehaviour
{
    private Slider healthSlider;

    private PlayerHealthController healthController;

    private void Start()
    {
        healthController = PlayerScript.instance.healthController;
        healthSlider = GetComponent<Slider>();

        healthController.health.onValueChange += UpdateHealth;


        UpdateHealth();
    }

    public void UpdateHealth()
    {
        healthSlider.value = healthController.GetHealth();
    }
}
