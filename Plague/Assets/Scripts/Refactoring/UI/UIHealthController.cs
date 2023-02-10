using System;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthController : MonoBehaviour
{
    private Slider healthSlider;

    private PlayerHealthController healthController;

    public UIHealthController()
    {
    }

    private void Start()
    {
        this.healthController = PlayerScript.instance.healthController;
        this.healthSlider = base.GetComponent<Slider>();
        this.healthController.health.onValueChange += new Stat.OnValueChange(this.UpdateHealth);
        this.UpdateHealth();
    }

    public void UpdateHealth()
    {
        this.healthSlider.@value = this.healthController.GetHealth();
    }
}