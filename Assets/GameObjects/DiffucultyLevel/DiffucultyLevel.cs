using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffucultyLevel : MonoBehaviour
{
    public static DiffucultyLevel Instance { get; private set; }

    public DifficultyType DifficultyType => difficultyType;

    const float MEDIUM_DIFFICULTY_THRESHOLD = 20f;
    const float END_DIFFICULTY_THRESHOLD = 30F;

    DifficultyType difficultyType = DifficultyType.Begin;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (difficultyType != DifficultyType.Middle && Doodle.Instance.Doodle_Pivot_Y > MEDIUM_DIFFICULTY_THRESHOLD && Doodle.Instance.Doodle_Pivot_Y < END_DIFFICULTY_THRESHOLD)
        {
            difficultyType = DifficultyType.Middle;
        }
        else if (difficultyType != DifficultyType.End && Doodle.Instance.Doodle_Pivot_Y > END_DIFFICULTY_THRESHOLD)
        {
            difficultyType = DifficultyType.End;
        }
    }
}
