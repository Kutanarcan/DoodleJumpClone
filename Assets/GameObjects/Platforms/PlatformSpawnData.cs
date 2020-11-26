using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlatformSpawnData", menuName = "ScriptableObject/PlatformSpawnData")]
public class PlatformSpawnData : ScriptableObject
{
    [SerializeField]
    Platform platformPrefab;
    [SerializeField]
    List<PlatformData> platformDatas = new List<PlatformData>();

    public Platform PlatformPrefab => platformPrefab;

    public Dictionary<DifficultyType, PlatformData> PlatformSpawnDataDict => platformSpawnDataDict;

    Dictionary<DifficultyType, PlatformData> platformSpawnDataDict = new Dictionary<DifficultyType, PlatformData>();

    void OnEnable()
    {
        for (int i = 0; i < platformDatas.Count; i++)
        {
            if (!platformSpawnDataDict.ContainsKey(platformDatas[i].DifficultyType))
            {
                platformSpawnDataDict.Add(platformDatas[i].DifficultyType, platformDatas[i]);
            }
        }
    }
}

[System.Serializable]
public class PlatformData
{
    [SerializeField]
    float spawnTime;
    [SerializeField]
    DifficultyType difficultyType;
    [SerializeField]
    SpawnFrequencyType spawnFrequencyType;
    [SerializeField]
    PlatformSpawnFrequency platformSpawnFrequency;

    public float spawnTimeBetweenPlatformSpawns => platformSpawnFrequency.SpawnFrequencyDict[spawnFrequencyType];
    public float SpawnTime => spawnTime;
    public DifficultyType DifficultyType => difficultyType;
    public SpawnFrequencyType SpawnFrequencyType => spawnFrequencyType;

}

public enum DifficultyType
{
    Begin,
    Middle,
    End
}
