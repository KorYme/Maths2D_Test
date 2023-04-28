using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCircleCollider : MonoBehaviour
{
    public bool IsColliding(Vector2 position, float radius)
    {
        return Vector2.Distance(transform.position, position) <= (transform.lossyScale.x / 2f) + radius;
    }
}
