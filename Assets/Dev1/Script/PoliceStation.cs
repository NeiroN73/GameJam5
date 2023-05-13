using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceStation : MonoBehaviour
{
    [SerializeField] private List<Cell> _listCells;
    private CycleSwitcher _cycleSwitcher;

    private void Start()
    {
        _cycleSwitcher = CycleSwitcher.Instance;
        _cycleSwitcher.SwitchedCycle += OnSwitchedCycle;

        for(int i = 0; i < transform.childCount; i++)
        {
            _listCells.Add(transform.GetChild(i).gameObject.GetComponent<Cell>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            _cycleSwitcher.LaunchNextCycle();
        }
    }

    private void OnSwitchedCycle(CycleSettingsSO settings)
    {
        _listCells[settings._cell].CreateItem();
    }
}