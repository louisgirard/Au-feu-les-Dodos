﻿using System.Collections.Generic;
using UnityEngine;

public class RodeurDetector : MonoBehaviour
{
    [SerializeField] RectTransform radar = null;
    [SerializeField] float arrowLimit = 20f;
    [SerializeField] float pointLimit = 10f;
    [SerializeField] GameObject rodeurPointPrefab = null;
    [SerializeField] GameObject rodeurArrowPrefab = null;
    Transform player;
    GameObject[] rodeurs;
    List<GameObject> rodeurPoints = new List<GameObject>();
    List<GameObject> rodeurArrows = new List<GameObject>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rodeurs = GameObject.FindGameObjectsWithTag("Rodeur");
        Setup();
    }

    void Update()
    {
        for(int i = 0; i < rodeurs.Length; i++)
        {
            if(rodeurs[i] == null)
            {
                rodeurArrows[i].SetActive(false);
                rodeurPoints[i].SetActive(false);
                continue;
            }
            Vector2 direction = (rodeurs[i].transform.position - player.position);
            if(direction.magnitude > arrowLimit)
            {
                rodeurArrows[i].SetActive(false);
                rodeurPoints[i].SetActive(false);
            }
            else if(direction.magnitude > pointLimit)
            {
                rodeurPoints[i].SetActive(false);
                rodeurArrows[i].SetActive(true);
                OrientateArrow(i, direction);
            }
            else
            {
                rodeurArrows[i].SetActive(false);
                rodeurPoints[i].SetActive(true);
                rodeurPoints[i].GetComponent<RectTransform>().anchoredPosition = radar.rect.size / 2 * direction / pointLimit;
            }
        }
    }

    private void Setup()
    {
        for (int i = 0; i < rodeurs.Length; i++)
        {
            GameObject rodeurPoint = Instantiate(rodeurPointPrefab, radar);
            rodeurPoints.Add(rodeurPoint);
            GameObject rodeurArrow = Instantiate(rodeurArrowPrefab, radar);
            rodeurArrows.Add(rodeurArrow);
        }
    }

    private void OrientateArrow(int index, Vector2 direction)
    {
        float angle = Vector2.Angle(new Vector2(0, 1), direction);
        if (direction.x > 0)
        {
            angle = -angle;
        }

        rodeurArrows[index].transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}