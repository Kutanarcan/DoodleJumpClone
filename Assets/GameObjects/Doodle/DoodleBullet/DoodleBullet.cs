using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleBullet : MonoBehaviour
{
    Vector2 moveTo;

    private void Awake()
    {
        Destroy(gameObject, 2f);
    }

    public void InitMovePosition(Vector2 moveTo)
    {
        this.moveTo = moveTo;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveTo, 13f * Time.deltaTime);

        if (transform.position.y >= moveTo.y)
        {
            Destroy(gameObject);
        }
    }
}
