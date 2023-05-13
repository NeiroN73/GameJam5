using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraBorderSwitchRooms : MonoBehaviour
{
    [SerializeField] private CinemachineConfiner _camera;
    private PolygonCollider2D _polygonCollider;

    private void Start()
    {
        _polygonCollider = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            _camera.m_BoundingShape2D = _polygonCollider;
        }
    }
}
