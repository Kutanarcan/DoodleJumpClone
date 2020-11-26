using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleInteract : MonoBehaviour
{
    Doodle doodle;

    private void Awake()
    {
        doodle = GetComponent<Doodle>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rocket rocket = other.GetComponent<Rocket>();

        if (rocket!=null)
        {
            doodle.DoodleMovement.CanFly = true;
            doodle.DoodleMovement.EnableRocket();
            Destroy(rocket.gameObject);
        }
    }
}
