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

    public Animation anim;

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
      
        transform.position = Vector2.MoveTowards(this.transform.position,spawn_point.position,Speed *Time.deltaTime);
        if(spawn_point.position.x<transform.position.x)
        {
            transform.localScale = new Vector3(-2, 2, transform.localScale.z);
        }else if(spawn_point.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(2, 2, transform.localScale.z);
        }
    }
    public void TimerIdle()
    {

    }
    public void Notice()
    {

    }
}
