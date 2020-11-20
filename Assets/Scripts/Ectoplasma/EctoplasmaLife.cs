using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EctoplasmaLife : Extinguishment
{
    GameObject slider;

    void Start() {
        max_health = health;
        slider = GameObject.FindWithTag("EctoplasmaLifeSlider");
        slider.SetActive(false);
    }

    void Update() {
        slider.GetComponent<Slider>().value = health/max_health;
    }

    public void StartFight() 
    {
        slider.SetActive(true);
    }

    private void Death()
    {
        print("ECtoplasma mort");
    }
}
