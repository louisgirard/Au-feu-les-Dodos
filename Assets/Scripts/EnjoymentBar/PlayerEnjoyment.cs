using UnityEngine;

public class PlayerEnjoyment : MonoBehaviour
{
    public int maxEnjoyment = 100;
    public int currentEnjoyment;

    public EnjoymentBar enjoymentBar;
    
    void Start()
    {
        currentEnjoyment = maxEnjoyment;
        enjoymentBar.SetMaxEnjoyment(maxEnjoyment);
    }

    private void Update()
    {
        print(currentEnjoyment);
    }

    public void TakeDamage(string action)
    {
        if (action == "Machibuse")
        {
            LoseEnjoyment(10);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        if (action == "Rodeur")
        {
            LoseEnjoyment(15);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        if (action == "Brulure")
        {
            LoseEnjoyment(5);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
    }

    public void TakePleasure(string action)
    {
        if (action == "Fire")
        {
            AddEnjoyment(1);
            enjoymentBar.SetEnjoyment(currentEnjoyment);
            print(currentEnjoyment);
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
