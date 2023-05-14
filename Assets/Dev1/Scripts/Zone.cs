using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private Computer _computer;
    [SerializeField] private string _nameZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Human human))
        {
            _computer.WarningSignal(_nameZone);
            print("check");
            Debug.Log(human.transform.name);
        }
    }
}
