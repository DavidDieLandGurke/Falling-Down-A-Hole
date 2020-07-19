using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Falling Level Asset", menuName = "Falling Level Asset")]
public class FallingLevelAsset : ScriptableObject
{
    public GameObject Prefab;

    public int Cooldown;
}
