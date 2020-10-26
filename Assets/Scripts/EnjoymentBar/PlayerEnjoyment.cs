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
   
       
    public void TakeDamage(string action)
    {
        if (action == "Machibuse")
        {
            currentEnjoyment -= 10;
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        if (action == "Rodeur")
        {
            currentEnjoyment -= 15;
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }
        if (action == "Brulure")
        {
            currentEnjoyment -= 5;
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }



    }

    public void TakePleasure(string action)
    {
        if (action == "Fire")
        {
            currentEnjoyment += 5;
            enjoymentBar.SetEnjoyment(currentEnjoyment);
        }

    }
}
