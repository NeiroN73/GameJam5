using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private PoliceStation _policeStation;
    [SerializeField] private string _nameZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Human human))
        {
            _policeStation.WarningSignal(_nameZone);
        }
    }
}
