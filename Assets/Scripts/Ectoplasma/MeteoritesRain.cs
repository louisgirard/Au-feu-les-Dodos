using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritesRain : MonoBehaviour
{
    public GameObject meteorite_prefab;

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(large_falling());
    }

    private void Update()
    {
    }

    IEnumerator large_falling()
    {
        Vector2 shift = new Vector2(Random.value * 6 - 3, Random.value * 6 - 3);
        GameObject meteorite = Instantiate(meteorite_prefab, (Vector2)transform.position + shift, Quaternion.identity);
        meteorite.SetActive(true);
        meteorite.GetComponent<Animator>().Play("Wait");
        meteorite.transform.SetParent(null);

        yield return new WaitForSeconds(0.2f);
        StartCoroutine(large_falling());
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
