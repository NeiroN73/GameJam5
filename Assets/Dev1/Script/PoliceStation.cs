using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceStation : MonoBehaviour
{
    [SerializeField] private List<Cell> _listCells;
    private CycleSwitcher _cycleSwitcher;

    private void Start()
    {
        //_cycleSwitcher.SwitchedCycle += OnSwitchedCycle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            
        }
    }

    private void OnSwitchedCycle(int currentCycle)
    {

    }
}