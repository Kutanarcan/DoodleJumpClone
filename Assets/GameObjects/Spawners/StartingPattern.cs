using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPattern : MonoBehaviour
{
    [SerializeField]
    Transform spawnPos;
    [SerializeField]
    Transform spawnXMin;
    [SerializeField]
    Transform spawnXMax;

    public float StartSpawnPosY => spawnPos.position.y;
    public float SpawnXMin => spawnXMin.position.x;
    public float SpawnXMax => spawnXMax.position.x;
}
