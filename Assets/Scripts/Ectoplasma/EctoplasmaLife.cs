using UnityEngine;
using UnityEngine.UI;

public class EctoplasmaLife : Extinguishment
{

    GameObject slider = null;

    void Start()
    {
        max_health = health;
        slider = GameObject.FindWithTag("EctoplasmaLifeSlider");
        slider.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Burning>().enabled = false;
    }

    void Update()
    {
        slider.GetComponent<Slider>().value = health/max_health;
    }

    public void StartFight() 
    {
        slider.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = true;
    }

    public void StopFight()
    {
        if (slider != null)
            slider.SetActive(false);
    }

    protected override void Death()
    {
        StopFight();
        GetComponent<EctoplasmaEndLevel>().StartDialogue();
    }
}
