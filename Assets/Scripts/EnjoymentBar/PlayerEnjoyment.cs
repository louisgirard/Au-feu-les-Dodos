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
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
  
        if (collision.CompareTag("Fire"))
        {
            TakePleasure(10);
        }

        if (collision.CompareTag("Machibuse"))
        {
            TakeDamage(2);
        }
    }
    void TakeDamage(int damage)
    {
        currentEnjoyment -= damage;
        enjoymentBar.SetEnjoyment(currentEnjoyment);
    }

    void TakePleasure(int pleasure)
    {
        currentEnjoyment += pleasure;
        enjoymentBar.SetEnjoyment(currentEnjoyment);
    }
}
