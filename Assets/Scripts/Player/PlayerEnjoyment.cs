﻿using UnityEngine;

public class PlayerEnjoyment : MonoBehaviour
{
    public float maxEnjoyment = 100;
    private float currentEnjoyment;
    private float timer = 0.0f;
    public float waitTime = 5.0f;

    public EnjoymentBar enjoymentBar;
    
    void Start()
    {
        currentEnjoyment = maxEnjoyment;
        enjoymentBar.SetMaxEnjoyment(maxEnjoyment);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > waitTime)
        {
            TakeDamage("Time");
            timer = 0.0f;
        }
    }

    public void TakeDamage(string action)
    {
        if (action == "Machibuse")
        {
            LoseEnjoyment(5);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        else if (action == "Rodeur")
        {
            LoseEnjoyment(10f);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        else if (action == "Burn")
        {
            LoseEnjoyment(2);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        else if (action == "Time")
        {
            LoseEnjoyment(2);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        else if (action == "Ectoplasma proximity explosion")
        {
            LoseEnjoyment(0.5f);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }

    }

    public void TakePleasure(string action)
    {
        if (action == "Fire")
        {
            AddEnjoyment(5);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        if (action == "Machibuse Death")
        {
            AddEnjoyment(2);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        if (action == "Rodeur Death")
        {
            AddEnjoyment(10);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        if (action == "Rodeur Damage")
        {
            AddEnjoyment(0.01f);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }


    }

    private void AddEnjoyment(float enjoyment)
    {
        currentEnjoyment = Mathf.Min(currentEnjoyment + enjoyment, maxEnjoyment);
    }

    private void LoseEnjoyment(float enjoyment)
    {
        currentEnjoyment = Mathf.Max(currentEnjoyment - enjoyment, 0);
    }
}