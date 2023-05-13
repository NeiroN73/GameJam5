using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    private BoxCollider2D _collider;

    public ItemSO _currentItem;

    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _humanoidMask;
    [SerializeField] private float _distanceMeleeAttack;

    [SerializeField] private float _distanceDistanceAttack;

    private Camera _camera;

    private Animator _animator;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();

        _camera = Camera.main;
    }

    private void Update()
    {
        Move();
        UseItem();
    }

    public void SetItem(ItemSO item)
    {
        _currentItem = item;
    }

    private void UseItem()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (_currentItem == null) return;

            switch (_currentItem.ItemType)
            {
                case ItemType.Gun:
                    //animator play something
                    print("gun");
                    DistanceAttack();
                    break;

                case ItemType.StunGun:
                    print("stunGun");
                    DistanceAttack();
                    break;

                case ItemType.PepperSpray:
                    print("pepperSpray");
                    MeleeAttack();
                    break;

                case ItemType.Baton:
                    print("baton");
                    MeleeAttack();
                    break;
            }
        }
    }

    private void MeleeAttack()
    {
        Vector2 useDirection = (_camera.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _attackRadius, useDirection, _distanceMeleeAttack, _humanoidMask);

        if (hits.Length <= 0) return;

        foreach (RaycastHit2D hit in hits)
        {
            print(hit.transform.gameObject.name);

            if(hit.transform.gameObject.TryGetComponent(out Human human))
            {
                human.ApplyDamage();    
            }
            else if(hit.transform.gameObject.TryGetComponent(out Robot robot))
            {
                robot.ApplyDamage();
            }
        }
    }

    private void DistanceAttack()
    {
        Vector2 useDirection = (_camera.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        RaycastHit2D ray = Physics2D.Raycast(transform.position, useDirection, _distanceDistanceAttack, _humanoidMask);

        if (ray == false) return;

        print(ray.transform.gameObject.name);
        
        if (ray.transform.gameObject.TryGetComponent(out Human human))
        {
            human.ApplyDamage();
        }
        else if (ray.transform.gameObject.TryGetComponent(out Robot robot))
        {
            robot.ApplyDamage();
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        movement = Vector2.ClampMagnitude(movement, 1);

        _rigidbody.velocity += movement * _speed * Time.deltaTime;
    }
}