using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessStandingLevelGenerator : MonoBehaviour
{
    public GameObject[] prefabs;

    public GameObject StartPrefab;

    Vector2 previousPosition = new Vector2(0, 0);

    void Start()
    {
        Instantiate(StartPrefab, previousPosition, Quaternion.identity);
    }

    void Update()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector2(0, previousPosition.y + 10), Quaternion.identity);
        previousPosition = new Vector2(0, previousPosition.y + 10);
    }
}
