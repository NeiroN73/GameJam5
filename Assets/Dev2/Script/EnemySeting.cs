using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeting : MonoBehaviour
{
    public Transform spawn_point;
    public float Timer;
    public float StartTime;
    public float Speed = 2;

    int i;

    private void Start()
    {
        i = Random.Range(0, 1);

    }
    private void FixedUpdate()
    {
        
        if(i==0)
        {
            Walking();
        }
        else
        {
            Idle();
        }
    }
    public void Idle()
    {
    
    }
    public void Walking()
    {
        Vector2 direction = spawn_point.position - transform.position;
        transform.Translate(direction * Speed * Time.deltaTime);
    }
    public void TimerIdle()
    {

    }
}
