using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarFill : MonoBehaviour
{
    public Health health;
    public Image fillImage;
    private Slider slider;

    //private Health maxHealth;
    //private Health currentHealth;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = health.currentHealth / health.maxHealth;
        slider.value = fillValue;
    }
}
