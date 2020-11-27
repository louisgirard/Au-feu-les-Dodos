using UnityEngine;

public class PlayerEnjoyment : MonoBehaviour
{
    public float maxEnjoyment = 100;
    public float currentEnjoyment;
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
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        else if (action == "Rodeur")
        {
            LoseEnjoyment(10f);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        else if (action == "Burn")
        {
            LoseEnjoyment(0.5f);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        else if (timeOn && action == "Time")
        {
            LoseEnjoyment(1);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        else if (action == "Ectoplasma fireball")
        {
            LoseEnjoyment(5f);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
    }

    public void TakePleasure(string action)
    {
        if (action == "Fire")
        {
            AddEnjoyment(2.5f);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        if (action == "Machibuse Death")
        {
            AddEnjoyment(1f);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        if (action == "Rodeur Death")
        {
            AddEnjoyment(15);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        if (action == "Rodeur Damage")
        {
            AddEnjoyment(0.015f);
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

    public void ActiveTime(bool val)
    {
        timeOn = val;
    }
}
