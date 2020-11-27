using UnityEngine;

public class PlayerEnjoyment : MonoBehaviour
{
    public float maxEnjoyment = 100;
    float currentEnjoyment;
    private float timer = 0.0f;
    public float waitTime = 5.0f;
    private bool timeOn = true;

    public EnjoymentBar enjoymentBar;

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
        }
        else if (action == "Rodeur")
        {
            LoseEnjoyment(10f);
        }
        else if (action == "Burn")
        {
            LoseEnjoyment(0.5f);
        }
        else if (timeOn && action == "Time")
        {
            LoseEnjoyment(2);
        }
        else if (action == "Ectoplasma fireball")
        {
            LoseEnjoyment(5f);
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
            AddEnjoyment(13);
        }
        if (action == "Rodeur Damage")
        {
            AddEnjoyment(0.015f);
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
}
