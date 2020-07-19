using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLevelGenerator : MonoBehaviour
{
    public FallingLevelAsset[] prefabs;

    public GameObject LastPrefab;

    public int LevelLength;

    Vector2 previousPosition = new Vector2(0, 0);

    private int cooldown;

    void Start()
    {
        Generate();
    }

    public void Generate()
    {
        Instantiate(prefabs[0].Prefab, previousPosition, Quaternion.identity);
        previousPosition = new Vector2(0, previousPosition.y - 10);
        Instantiate(prefabs[0].Prefab, previousPosition, Quaternion.identity);

        for (int length = 0; length < LevelLength; length++)
        {
            int PrefabNumber = 0;
            if (cooldown > 0)
            {
                PrefabNumber = 0;
                cooldown--;
            }
            else
            {
                PrefabNumber = Random.Range(0, prefabs.Length);
            }

            Instantiate(prefabs[PrefabNumber].Prefab, new Vector2(0, previousPosition.y - 10), Quaternion.identity);
            previousPosition = new Vector2(0, previousPosition.y - 10);

            if (prefabs[PrefabNumber].Cooldown > 0)
            {
                cooldown = prefabs[PrefabNumber].Cooldown;
            }
        }

        Instantiate(LastPrefab, new Vector2(0, previousPosition.y - 10), Quaternion.identity);

        previousPosition = new Vector2(0, 0);
    }

}
