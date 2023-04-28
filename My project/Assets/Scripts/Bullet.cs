using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] float _initialSpeed;
    [SerializeField] float _gravityScale;
    [SerializeField] Vector2 _windVelocity;

    Vector2 _velocity;

    MyCircleCollider _ballCollider;
    MyFloorCollider _floorCollider;

    public void Initialize(Vector2 direction, float power, MyCircleCollider ballCollider, MyFloorCollider floorCollider)
    {
        _velocity = direction * power * _initialSpeed;
        _ballCollider = ballCollider;
        _floorCollider = floorCollider;
        StartCoroutine(DestroyCoroutine());
    }

    private void Update()
    {
        transform.position += (Vector3)_velocity * Time.deltaTime;
        _velocity += (Vector2.down * _gravityScale + _windVelocity) * Time.deltaTime;
        if (_ballCollider.IsColliding(transform.position, transform.lossyScale.x/2f))
        {
            Debug.Log("CA TOUCHE  LA BALLE");
            Destroy(gameObject);
        }
        else if (_floorCollider.IsUnderTheFloor(transform.position, transform.localScale.x/2f))
        {
            Debug.Log("CA TOUCHE LE SOL");
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Empêche le jeu de lagger à cause d'un trop grand nombre de balles instanciées
    /// </summary>
    /// <returns></returns>
    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
