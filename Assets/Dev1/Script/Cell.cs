using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Item _itemPrefab;

    public void CreateItem()
    {
        var item = Instantiate(_itemPrefab, transform.position, Quaternion.identity);
        //print(gameObject.name);
    }
}
