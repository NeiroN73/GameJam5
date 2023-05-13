using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Humanoid : MonoBehaviour
{
    [SerializeField] private List<Transform> _listPoints = new List<Transform>();

    private Transform _currentPoint;
    [SerializeField] private float _speed;

    private void Start()
    {
        GetRandomPoint();
    }

    private void GetRandomPoint()
    {
        _currentPoint = _listPoints[Random.Range(0, _listPoints.Count)];
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f)
        {
            GetRandomPoint();
        }
    }
}
