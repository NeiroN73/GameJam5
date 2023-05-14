using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
   public Collider2D [] collider;
    public MeshCollider Mesh;
    public float maxX, maxY;
    public Vector2 PointPos;

    private bool _check =false;

    
    public Vector2 size = new Vector2 (2,2);

    public void Start()
    {
        PointGenerator();
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "Block")
        {
         
            PointGenerator();
        }
    }

    private void PointGenerator()
    {
        maxX = Random.Range(Mesh.transform.position.x - Random.Range(3, Mesh.bounds.extents.x), Mesh.transform.position.x + Random.Range(3, Mesh.bounds.extents.x));
        maxY = Random.Range(Mesh.transform.position.y - Random.Range(3, Mesh.bounds.extents.y), Mesh.transform.position.y + Random.Range(3, Mesh.bounds.extents.y));
        //PointPos = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxZ, maxZ));
        gameObject.transform.position = new Vector2(maxX,maxY);
    }

    public bool CheckSpawnPoint()
    {
        //collider = Physics2D.OverlapCircleAll(gameObject.transform.position, 2);

        if (collider == null)
        {
            return true;
        }
        else
        {
            collider = null;
            return false;
        }

    }
}
