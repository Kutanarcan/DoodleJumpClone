using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingPlatform : Platform
{
    Vector2 movementVector;
    float startingTransformY;

    private void Start()
    {
        startingTransformY = transform.position.y;
        movementVector = Vector2.right * BlockSpawner.Instance.StartingPattern.SpawnXMax;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (transform.position.x <= BlockSpawner.Instance.StartingPattern.SpawnXMin)
        {
            movementVector = Vector2.right * BlockSpawner.Instance.StartingPattern.SpawnXMax;
        }
        else if (transform.position.x >= BlockSpawner.Instance.StartingPattern.SpawnXMax)
        {
            movementVector = Vector2.right * BlockSpawner.Instance.StartingPattern.SpawnXMin;
        }
        movementVector.y = startingTransformY;

        transform.position = Vector2.MoveTowards(transform.position, movementVector, 1f * Time.deltaTime);
    }
}
