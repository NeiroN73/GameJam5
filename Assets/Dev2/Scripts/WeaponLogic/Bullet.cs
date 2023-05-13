using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _damage;

    public void Initialize(Vector3 direction, float dropForce, int damage)
    {
        _damage = damage;
        Shoot(dropForce);
    }

    public void Shoot(float dropForce)
    {
        _rigidbody.AddForce(transform.forward * dropForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            //здесь вызывать метод принятия урона врагом с полем _damage и запуск метода анимации у врага
        }

        Destroy(gameObject);
    }
}
