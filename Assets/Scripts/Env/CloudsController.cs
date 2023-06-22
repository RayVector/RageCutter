using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsController : MonoBehaviour
{
    [Header("Main")]
    public bool isMoving = true;
    public float speed = 0.15f;

    private void FixedUpdate()
    {
        if (isMoving) MoveSelf();
    }

    public void MoveSelf()
    {
        transform.Translate((speed) * Time.deltaTime * Vector2.left);
    }
}
