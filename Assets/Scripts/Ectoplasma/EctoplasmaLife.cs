﻿using UnityEngine;
using UnityEngine.UI;

public class EctoplasmaLife : Extinguishment
{
    GameObject slider;

    void Start()
    {
        max_health = health;
        slider = GameObject.FindWithTag("EctoplasmaLifeSlider");
        slider.SetActive(false);
    }

    void Update()
    {
        slider.GetComponent<Slider>().value = health/max_health;
    }

    public void StartFight() 
    {
        slider.SetActive(true);
    }

    public void StopFight()
    {
        slider.SetActive(false);
    }

    protected override void Death()
    {
        StopFight();
        GetComponent<EctoplasmaEndLevel>().StartDialogue();
    }
}
