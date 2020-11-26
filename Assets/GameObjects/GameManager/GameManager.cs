using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if (Doodle.Instance.DoodleMovement.Body2D.velocity.y < DoodleMovement.DOODLE_DIE_VELOCITY_Y)
        {
            Debug.Log("Doodle Died");
            Doodle.Instance.DoodleMovement.StopVelocity();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
