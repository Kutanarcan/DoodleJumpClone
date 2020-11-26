using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera mainCamera;
    const float FOLLOW_OFFSET_Y = 2.1f;
    Vector3 followPos;

    void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Start()
    {
        followPos = new Vector3(0, Doodle.Instance.transform.position.y + FOLLOW_OFFSET_Y, -10);
    }

    void Update()
    {
        FollowDoodleYPos();
    }

    void FollowDoodleYPos()
    {
        followPos.y = Doodle.Instance.transform.position.y + FOLLOW_OFFSET_Y;

        mainCamera.transform.position = followPos;
    }
}
