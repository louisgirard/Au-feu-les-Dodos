using UnityEngine;

public class PlayerEnjoyment : MonoBehaviour
{
    public int maxEnjoyment = 100;
    private int currentEnjoyment;

    public EnjoymentBar enjoymentBar;
    
    void Start()
    {
        currentEnjoyment = maxEnjoyment;
        enjoymentBar.SetMaxEnjoyment(maxEnjoyment);
    }

    public void TakeDamage(string action)
    {
        if (action == "Machibuse")
        {
            LoseEnjoyment(5);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        if (action == "Rodeur")
        {
            LoseEnjoyment(5);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        if (action == "Burn")
        {
            LoseEnjoyment(2);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        if (action == "Time")
        {
            LoseEnjoyment(2);
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
            AddEnjoyment(2);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }


    }

    private void AddEnjoyment(int enjoyment)
    {
        currentEnjoyment = Mathf.Min(currentEnjoyment + enjoyment, maxEnjoyment);
    }

    private void LoseEnjoyment(int enjoyment)
    {
        currentEnjoyment = Mathf.Max(currentEnjoyment - enjoyment, 0);
    }
}
