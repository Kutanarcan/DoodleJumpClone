using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlatformSpawnFrequency", menuName = "ScriptableObject/PlatformSpawnFrequency")]
public class PlatformSpawnFrequency : ScriptableObject
{
    Dictionary<SpawnFrequencyType, float> spawnFrequencyDict = new Dictionary<SpawnFrequencyType, float>();

    public Dictionary<SpawnFrequencyType, float> SpawnFrequencyDict => spawnFrequencyDict;

    private void OnEnable()
    {
        spawnFrequencyDict.Add(SpawnFrequencyType.Low, 2f);
        spawnFrequencyDict.Add(SpawnFrequencyType.Medium, 1.75f);
        spawnFrequencyDict.Add(SpawnFrequencyType.High, 1.5f);
    }
}

public enum SpawnFrequencyType
{
    Low,
    Medium,
    High
}
