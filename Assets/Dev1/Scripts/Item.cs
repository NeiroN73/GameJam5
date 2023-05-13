using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO _item;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _force;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.SetItem(_item);
            Destroy(gameObject);
        }
    }

    public void ThrowItem()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(-transform.up * _force);
    }
}
