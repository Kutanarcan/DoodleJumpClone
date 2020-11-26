using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlatformSpawnDataList", menuName = "ScriptableObject/PlatformSpawnDataList")]
public class PlatformSpawnDataList : ScriptableObject
{
    [SerializeField]
    List<PlatformSpawnData> platformSpawnDatas = new List<PlatformSpawnData>();

    public List<PlatformSpawnData> PlatformSpawnDatas => platformSpawnDatas;
}
