using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DodoUI : MonoBehaviour
{
    [SerializeField] CircularBar circularBarPrefab = null;
    [SerializeField] Image circle = null;
    [SerializeField] Gradient circleGradient = null;
    [SerializeField] Image dodoHead = null;

    Sprite[] heads = null;
    readonly List<CircularBar> healthBars = new List<CircularBar>();
    bool isBlinking = false;

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

    public void SetupHead(Sprite[] dodoHeads)
    {
        heads = dodoHeads;
        dodoHead.sprite = heads[0];
    }

    public void UpdateHealth(float health, bool negative = false)
    {
        if(negative && !isBlinking && health > 0)
        {
            StartCoroutine(HeadBlink());
        }
        UpdateBars(health);
        UpdateCircle(health);
        UpdateHead(health);
    }

    private void UpdateBars(float health)
    {
        // Fill or not the bars
        for (int i = 0; i < healthBars.Count; i++)
        {
            if (i == Mathf.Floor(health))
            {
                healthBars[i].SetAmount(health - Mathf.Floor(health));
            }
            else if (i > health)
            {
                healthBars[i].SetAmount(0);
            }
            else
            {
                healthBars[i].SetAmount(1);
            }
        }
    }

    private void UpdateCircle(float health)
    {
        circle.color = circleGradient.Evaluate(1 - health / healthBars.Count);
    }

    private void UpdateHead(float health)
    {
        if(health == 0)
        {
            dodoHead.sprite = heads[heads.Length - 1];
        }
        else
        {
            int index = heads.Length - Mathf.CeilToInt(health / healthBars.Count * (heads.Length - 1)) - 1;
            dodoHead.sprite = heads[index];
        }
    }

    IEnumerator HeadBlink()
    {
        if (!isActiveAndEnabled) yield return null;

        float timeBetweenBlink = 0.2f;
        isBlinking = true;
        for (int i = 0; i < 3; i++)
        {
            dodoHead.enabled = false;
            yield return new WaitForSeconds(timeBetweenBlink);
            dodoHead.enabled = true;
            yield return new WaitForSeconds(timeBetweenBlink);
        }
        isBlinking = false;
    }

    public bool IsBlinking()
    {
        return isBlinking;
    }

    public void ResetHead()
    {
        isBlinking = false;
        dodoHead.enabled = true;
    }
}
