using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO _item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.SetItem(_item);
            Destroy(gameObject);
        }
    }
}
