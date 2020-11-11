using System.Collections.Generic;
using UnityEngine;

public class DodoUI : MonoBehaviour
{
    [SerializeField] CircularBar circularBarPrefab = null;
    readonly List<CircularBar> healthBars = new List<CircularBar>();

    public void SetupHealthBars(int health)
    {
        float offset = 10; // in degrees

        for (int i = 0; i < health; i++)
        {
            CircularBar bar = Instantiate(circularBarPrefab, transform);

            bar.SetDegrees(360 / health - offset);
            bar.transform.rotation = Quaternion.Euler(0, 0, -i * 360 / health - offset / 2);

            healthBars.Add(bar);
        }
    }

    public void UpdateHealth(float health)
    {
        // Fill or not the bars
        for (int i = 0; i < healthBars.Count; i++)
        {
            if(i == Mathf.Floor(health))
            {
                healthBars[i].SetAmount(health - Mathf.Floor(health));
            }
            else if(i > health)
            {
                healthBars[i].SetAmount(0);
            }
            else
            {
                healthBars[i].SetAmount(1);
            }
        }
    }
}
