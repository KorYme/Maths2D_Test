using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform _startPoint;
    [SerializeField] Transform _endPoint;

    [Header("Parameters")]
    [SerializeField] float _ballSpeed;

    Vector2 _direction;

    private void Start()
    {
        transform.position = _startPoint.position;
        _direction = (_endPoint.position - _startPoint.position).normalized;
    }

    private void Update()
    {
        transform.position += (Vector3)_direction * _ballSpeed * Time.deltaTime;
        if (Vector2.Dot(-_direction, transform.position - _endPoint.position) <= 0)
        {
            transform.position = _startPoint.position;
        }
    }
}
