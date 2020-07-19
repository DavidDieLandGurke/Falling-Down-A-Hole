using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingLevelGenerator : MonoBehaviour
{
    public GameObject[] prefabs;

    public GameObject StartPrefab;
    public GameObject EndPrefab;

    public int LevelLength;

    Vector2 previousPosition = new Vector2(0, 0);

    void Start()
    {
        Instantiate(StartPrefab, previousPosition, Quaternion.identity);
        
        for(int length = 0; length < LevelLength; length++)
        {
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector2(0, previousPosition.y + 10), Quaternion.identity);
            previousPosition = new Vector2(0, previousPosition.y + 10);
        }

        Instantiate(EndPrefab, new Vector2(0, previousPosition.y + 10), Quaternion.identity);
    }

}
