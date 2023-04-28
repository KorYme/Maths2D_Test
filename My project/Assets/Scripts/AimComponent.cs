using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimComponent : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform _cursor;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] MyCircleCollider _ballCircleCollider;
    [SerializeField] MyFloorCollider _floorCollider;

    [Header("Parameters")]
    [SerializeField] float _minimumDistance;
    [SerializeField] float _maximumDistance;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _powerSpeed;


    float _currentPower;
    float _currentRotationAngle; // In radian

    private void Start()
    {
        _currentPower = 0.5f;
        _cursor.position = transform.position + (Vector3)Vector2.Lerp(Vector2.up * _minimumDistance, Vector2.up * _maximumDistance, _currentPower);
        _currentRotationAngle = Mathf.Atan2((_cursor.position - transform.position).normalized.y, (_cursor.position - transform.position).normalized.x);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _currentRotationAngle = Mathf.Clamp(_currentRotationAngle + Time.deltaTime * _rotationSpeed, 0f , Mathf.PI);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _currentRotationAngle = Mathf.Clamp(_currentRotationAngle - Time.deltaTime * _rotationSpeed, 0f, Mathf.PI);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _currentPower = Mathf.Clamp01(_currentPower + Time.deltaTime * _powerSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _currentPower = Mathf.Clamp01(_currentPower - Time.deltaTime * _powerSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity)
                .GetComponent<Bullet>().Initialize((_cursor.position - transform.position).normalized, 1 + _currentPower, _ballCircleCollider, _floorCollider);
        }
        _cursor.position = transform.position + new Vector3( Mathf.Cos(_currentRotationAngle) * Mathf.Lerp(_minimumDistance, _maximumDistance, _currentPower),
            Mathf.Sin(_currentRotationAngle) * Mathf.Lerp(_minimumDistance, _maximumDistance, _currentPower), 0f);
    }
}
