using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Transform jumpRaycastPoint;
    [SerializeField]
    LayerMask platformMask;
    [SerializeField]
    GameObject rocket;

    public Rigidbody2D Body2D => body2D;
    public bool CanFly { get; set; }
    public const float DOODLE_DIE_VELOCITY_Y = -20F;

    Rigidbody2D body2D;
    float horizontal;

    float jumpForce;
    float borderMinX;
    float borderMaxX;
    float flyTimer;

    Vector2 borderVector;

    const float BORDER_OFFSET = 0.4F;
    const float FLY_TIME = 5F;

    private void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        borderMinX = BlockSpawner.Instance.StartingPattern.SpawnXMin - BORDER_OFFSET;
        borderMaxX = BlockSpawner.Instance.StartingPattern.SpawnXMax + BORDER_OFFSET;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Flip();
        ChangeBorder();
    }

    private void FixedUpdate()
    {
#if UNITY_ANDROID
        jumpForce = 8.5f;
        body2D.AddForce(Input.acceleration * speed);
#endif
#if UNITY_EDITOR
        jumpForce = 7f;
        body2D.AddForce(Vector2.right * horizontal * speed);
#endif

        if (!CanFly)
            Jump();
        else
            Fly();
    }

    private void Fly()
    {
        if (flyTimer <= FLY_TIME)
        {
            body2D.velocity = new Vector2(body2D.velocity.x, 20f);
            flyTimer += Time.fixedDeltaTime;
        }
        else
        {
            rocket.SetActive(false);
            CanFly = false;
        }
    }

    private void Jump()
    {
        RaycastHit2D rayInfo = Physics2D.Raycast(jumpRaycastPoint.position, Vector2.down, 0.1f, platformMask);

        if (rayInfo.collider != null)
        {
            IsInJumpingVelocity();
        }
    }

    private void Flip()
    {
        transform.eulerAngles = horizontal <= 0 ? Vector2.zero : Vector2.down * 180f;
    }

    private void ChangeBorder()
    {
        if (transform.position.x <= borderMinX)
        {
            borderVector.x = borderMaxX;
            borderVector.y = transform.position.y;
            transform.position = borderVector;
        }
        else if (transform.position.x >= borderMaxX)
        {
            borderVector.x = borderMinX;
            borderVector.y = transform.position.y;
            transform.position = borderVector;
        }
    }

    private void IsInJumpingVelocity()
    {
        if (body2D.velocity.y <= -1f)
        {
            body2D.velocity = Vector2.zero;
            body2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void StopVelocity()
    {
        body2D.velocity = Vector2.zero;
    }
    
    public void EnableRocket()
    {
        rocket.SetActive(true);
    }
}
