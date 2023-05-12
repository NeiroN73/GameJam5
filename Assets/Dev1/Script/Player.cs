using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    private BoxCollider2D _collider;

    private Item _currentItem;

    [SerializeField] private float _attackRadius;
    [SerializeField] private Vector2 _offset;

    private Camera _camera;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();

        _camera = Camera.main;
    }

    private void Update()
    {
        Move();
        UseItem();
    }

    public void SetItem(Item item)
    {
        _currentItem = item;
    }

    private void UseItem()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 useDirection = (_camera.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

            //RaycastHit2D hit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0, useDirection, 10, 3);
            //RaycastHit2D hit = Physics2D.CircleCast(_collider.bounds.center, 5, useDirection * 5);
            Collider2D[] hits = Physics2D.OverlapCircleAll(new Vector2(transform.position.x + _offset.x, transform.position.y + _offset.y), _attackRadius, 3);

            if (hits.Length <= 0) return;

            for(int i = 0; i < hits.Length; i++)
            {
                print("check");
                hits[i].gameObject.TryGetComponent(out Human human);
                human.ApplyDamage();
                
            }
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(new Vector2(transform.position.x + _offset.x, transform.position.y + _offset.y), _attackRadius);
    }
}