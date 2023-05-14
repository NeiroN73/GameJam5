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

    public List<CycleSettingsSO> _listCycleSettings;

    [SerializeField] private GameObject _restartCyclePanel;
    [SerializeField] private GameObject _nextCyclePanel;

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
        //SwitchedCycle?.Invoke(_listCycleSettings[_currentCycle]);
        _currentCycle++;
        Debug.Log(_currentCycle);
        _nextCyclePanel.SetActive(false);
        SceneManager.LoadSceneAsync(0);
    }

    public void RestartCycle()
    {
        Debug.Log(_currentCycle);
        _restartCyclePanel.SetActive(false);
        SceneManager.LoadSceneAsync(0);
    }

    public void ActivateRestartPanel()
    {
        _restartCyclePanel.SetActive(true);
    }

    public void ActivateNextPanel()
    {
        _nextCyclePanel.SetActive(true);
    }
}