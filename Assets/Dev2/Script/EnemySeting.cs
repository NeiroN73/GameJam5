using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeting : MonoBehaviour
{
    public GameObject Box;

    public MeshCollider Plane;

    public float x, y;
    private bool _check;

    private Collider [] _collidrs;

    private Vector2 sizeCol= new Vector2(1f,1f);

    private Vector3 PointPos;
    private Vector3 testV;
    private void Start()
    {
        PointGenerator();
    }
    
    public void PointGenerator()
    {
        x = Random.Range(Plane.transform.position.x - Random.Range(0,Plane.bounds.extents.x), Plane.transform.position.x + Random.Range(0, Plane.bounds.extents.x));
        y = Random.Range(Plane.transform.position.y - Random.Range(0, Plane.bounds.extents.y), Plane.transform.position.y + Random.Range(0, Plane.bounds.extents.y));
        PointPos = new Vector3(x, y);
        testV = new Vector3(PointPos.x, PointPos.y, 20);
        _check = CheckSpawnPoint(testV);

        if(_check)
        {
            Box.transform.position = PointPos;
        }
        else
        {
            print(false);
        }
    }
    public bool CheckSpawnPoint(Vector3 spawnpos)
    {
        Ray ray = new Ray(transform.position = spawnpos, transform.forward);
        Debug.DrawRay(transform.position = spawnpos, transform.forward*200f,Color.red);
        _collidrs = Physics.OverlapBox(spawnpos,sizeCol);
        return (_collidrs.Length > 0) ? false : true;

       
    }
    private void Update()
    {
        CheckSpawnPoint(PointPos);
    }
}
