using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeting : MonoBehaviour
{
    public Transform spawn_point;

    public MeshCollider Plane;

    
    private bool _check;

    private Collider [] _collidrs;

    private Vector2 sizeCol= new Vector2(1f,1f);

    private Vector3 PointPos;
    private Vector3 value = new Vector3(3,3,3);
    private void Start()
    {
        PointGenerator();
        
    }
    
    private void PointGenerator()
    {
        
        PointPos = new Vector3(Random.Range(spawn_point.position.x - value.x,spawn_point.position.x + value.x), 
            Random.Range(spawn_point.position.z - value.z, spawn_point.position.z + value.z));
        
        _check = CheckSpawnPoint(PointPos);

        if(_check)
        {
            gameObject.transform.position = PointPos;
        }
        else
        {
            print(false);
        }
    }
    public bool CheckSpawnPoint(Vector3 spawnpos)
    {
      
        _collidrs = Physics.OverlapBox(spawnpos,sizeCol);
        return (_collidrs.Length > 0) ? false : true;

       
    }
    private void Update()
    {
        CheckSpawnPoint(PointPos);
    }
}
