using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType _itemType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.SetItem(this);
            Destroy(gameObject);
        }
    }
}

public enum ItemType
{
    None,
    Gun,
    Baton,
    StunGun,
    PepperSpray
}
