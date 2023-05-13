using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CycleSwitcher : MonoBehaviour
{
    private static int _currentCycle;

    public Action<int> SwitchedCycle;

    [SerializeField] private CycleSettingsSO _cycleSettings;

    private void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

    public void LaunchNextCycle()
    {
        SwitchedCycle?.Invoke(_currentCycle);
        _currentCycle++;
        Debug.Log(_currentCycle);
        SceneManager.LoadSceneAsync(0);
    }
}