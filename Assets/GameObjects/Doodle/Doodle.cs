using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doodle : MonoBehaviour
{
    public static Doodle Instance { get; private set; }

    public float Doodle_Pivot_Y => transform.position.y;

    public DoodleMovement DoodleMovement => doodleMovement;

    DoodleMovement doodleMovement;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        doodleMovement = GetComponent<DoodleMovement>();

    }
}
