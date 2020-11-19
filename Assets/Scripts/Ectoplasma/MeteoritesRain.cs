using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritesRain : MonoBehaviour
{
    public GameObject meteorite_prefab;

    private Transform player;
    private int meteorites_count;
    private float rain_duration;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        EctoplasmaPatternsSetUp paramaters = GameObject.FindWithTag("Ectoplasma").GetComponent<EctoplasmaPatternsSetUp>();
        meteorites_count = paramaters.meteorites_count;
        rain_duration = paramaters.rain_duration;
        StartCoroutine(large_falling(1));
    }

    IEnumerator large_falling(int cpt)
    {
        Vector2 shift = new Vector2(Random.value * 8 - 4, Random.value * 6 - 3);
        GameObject meteorite = Instantiate(meteorite_prefab, (Vector2)transform.position + shift, Quaternion.identity);
        meteorite.SetActive(true);
        meteorite.GetComponent<Animator>().Play("Wait");
        meteorite.transform.SetParent(null);

        if (cpt <= meteorites_count) {
            yield return new WaitForSeconds(rain_duration / (float)meteorites_count);
            StartCoroutine(large_falling(cpt+1));
        }
    }
    /*
    IEnumerator player_falling()
    {
        Vector2 shift = new Vector2(Random.value * 6 - 3, Random.value * 6 - 3);
        GameObject meteorite = Instantiate(meteorite_prefab, (Vector2)transform.position + shift, Quaternion.identity);
        meteorite.SetActive(true);
        meteorite.GetComponent<Animator>().Play("Wait");
        meteorite.transform.SetParent(null);

        yield return new WaitForSeconds(0.2f);
        StartCoroutine(fall());
    }*/

}
