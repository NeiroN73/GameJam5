using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public ItemType ItemType;
    public Sprite Sprite;
}

public enum ItemType
{
    None,
    Gun,
    Baton,
    StunGun,
    PepperSpray
}
