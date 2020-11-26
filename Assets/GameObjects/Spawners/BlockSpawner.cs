using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public static BlockSpawner Instance { get; private set; }

    [SerializeField]
    PlatformSpawnDataList platformSpawnDataList;
    [SerializeField]
    StartingPattern startingPattern;

    float nextSpawnTimer;
    float spawnOffset;

    Vector2 spawnPos = Vector2.zero;
    PlatformSpawnData platformSpawnData;

    const float DOODLE_DISTANCE_OFFSET = 10F;

    public StartingPattern StartingPattern => startingPattern;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        platformSpawnData = platformSpawnDataList.PlatformSpawnDatas[0];
    }

    void Start()
    {
        spawnOffset = startingPattern.StartSpawnPosY;
    }

    void Update()
    {
        HandlePlatformSpawn();
    }

    void HandlePlatformSpawn()
    {
        nextSpawnTimer += Time.deltaTime;

        if (Doodle.Instance.Doodle_Pivot_Y > spawnOffset - DOODLE_DISTANCE_OFFSET)
        {
            SelectPlatformSpawnDataByTime();
            CalculateSpawnPos();
            SpawnPlatform();
        }
    }

    void SelectPlatformSpawnDataByTime()
    {
        if (nextSpawnTimer > platformSpawnData.PlatformSpawnDataDict[DiffucultyLevel.Instance.DifficultyType].SpawnTime)
        {
            int index = Random.Range(0, platformSpawnDataList.PlatformSpawnDatas.Count);
            platformSpawnData = platformSpawnDataList.PlatformSpawnDatas[index];
            nextSpawnTimer = 0;
        }
    }

    void SpawnPlatform()
    {
        Instantiate(platformSpawnData.PlatformPrefab, spawnPos, Quaternion.identity);
        spawnOffset += platformSpawnData.PlatformSpawnDataDict[DiffucultyLevel.Instance.DifficultyType].spawnTimeBetweenPlatformSpawns;
    }

    void CalculateSpawnPos()
    {
        spawnPos.y = spawnOffset;
        spawnPos.x = Random.Range(startingPattern.SpawnXMin, startingPattern.SpawnXMax);
    }
}
