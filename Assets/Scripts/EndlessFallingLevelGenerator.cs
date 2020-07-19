using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessFallingLevelGenerator : MonoBehaviour
{
    public FallingLevelAsset[] prefabs;

    Vector2 previousPosition = new Vector2(0, 0);

    private int cooldown;

    void Start()
    {
        Instantiate(prefabs[0].Prefab, previousPosition, Quaternion.identity);
        previousPosition = new Vector2(0, previousPosition.y - 10);
        Instantiate(prefabs[0].Prefab, previousPosition, Quaternion.identity);
    }

    void Update()
    {
        Generate();
    }

    public void Generate()
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

}
