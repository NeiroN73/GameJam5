using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CycleSwitcher : MonoBehaviour
{
    public static CycleSwitcher Instance { get; private set; }

    public int _currentCycle;

    public Action<CycleSettingsSO> SwitchedCycle;

    [SerializeField] private CycleSettingsSO _cycleSettings;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    public void LaunchNextCycle()
    {
        SwitchedCycle?.Invoke(_cycleSettings);
        _currentCycle++;
        Debug.Log(_currentCycle);
        SceneManager.LoadSceneAsync(0);
    }

    public void RestartCycle()
    {
        Debug.Log(_currentCycle);
        SceneManager.LoadSceneAsync(0);
    }
}