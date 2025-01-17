﻿using UnityEngine;
using System.Collections;

public class PlayerEnjoyment : MonoBehaviour
{
    public float maxEnjoyment = 100;
    float currentEnjoyment;
    private float timer = 0.0f;
    public float waitTime = 5.0f;
    private bool timeOn = true;

    public EnjoymentBar enjoymentBar;

    public Animator cameraAnimation;

    void Start()
    {
        currentEnjoyment = maxEnjoyment;
        enjoymentBar.SetMaxEnjoyment(maxEnjoyment);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
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
            CameraShake();
        }
        else if (action == "Rodeur")
        {
            LoseEnjoyment(14f);
            CameraShake();
        }
        else if (action == "Burn")
        {
            LoseEnjoyment(0.5f);
        }
        else if (timeOn && action == "Time")
        {
            LoseEnjoyment(1.8f);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        else if (action == "Ectoplasma fireball")
        {
            LoseEnjoyment(5f);
            CameraShake();
        }
    }

    public void TakePleasure(string action)
    {
        if (action == "Fire")
        {
            AddEnjoyment(2.5f);
        }
        if (action == "Machibuse Death")
        {
            AddEnjoyment(1f);
        }
        if (action == "Rodeur Death")
        {
            AddEnjoyment(15);
        }
        if (action == "Rodeur Damage")
        {
            AddEnjoyment(0.09f);
        }
    }

    public void AddEnjoyment(float enjoyment)
    {
        currentEnjoyment = Mathf.Min(currentEnjoyment + enjoyment, maxEnjoyment);
        enjoymentBar.SetEnjoyment(currentEnjoyment);
    }

    private void LoseEnjoyment(float enjoyment)
    {
        currentEnjoyment = Mathf.Max(currentEnjoyment - enjoyment, 0);
        enjoymentBar.SetEnjoyment(currentEnjoyment);
    }

    public bool IsDead()
    {
        return currentEnjoyment == 0;
    }

    public void ActiveTime(bool val)
    {
        timeOn = val;
    }

    private bool shaking = false;

    public void CameraShake()
    {
        if (!shaking)
        {
            cameraAnimation.SetTrigger("shake");
            shaking = true;
            StartCoroutine(shake_time());
        }
    }

    IEnumerator shake_time()
    {
        yield return new WaitForSeconds(0.2f);
        shaking = false;
    }
}
