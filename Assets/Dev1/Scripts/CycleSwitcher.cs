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
        _nextCyclePanel.SetActive(false);
        _restartCyclePanel.SetActive(false);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(_restartCyclePanel);
            DontDestroyOnLoad(_nextCyclePanel);
            return;
        }

        Destroy(gameObject);
        Destroy(_restartCyclePanel);
        Destroy(_nextCyclePanel);
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