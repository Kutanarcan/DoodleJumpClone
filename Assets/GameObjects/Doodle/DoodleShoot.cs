using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleShoot : MonoBehaviour
{
    [SerializeField]
    Sprite idle;
    [SerializeField]
    Sprite shoot;
    [SerializeField]
    DoodleBullet doodleBullet;
    [SerializeField]
    Transform bulletSpawnPos;

    SpriteRenderer doodleSpriteRenderer;

    private void Awake()
    {
        doodleSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            doodleSpriteRenderer.sprite = shoot;
            Shoot();
        }

        if (Input.GetMouseButtonUp(0))
        {
            doodleSpriteRenderer.sprite = idle;
        }
    }

    void Shoot()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float offset = worldPosition.x > 0 ? 1f : -1f;

        DoodleBullet bullet = Instantiate(doodleBullet, bulletSpawnPos.position, Quaternion.identity);
        bullet.InitMovePosition(new Vector2(worldPosition.x + offset, transform.position.y + 10f));
    }
}
