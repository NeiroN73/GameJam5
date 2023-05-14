using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class CycleSwitcher : MonoBehaviour
{
    public static CycleSwitcher Instance { get; private set; }

    public int _currentCycle;

    public Action<CycleSettingsSO> SwitchedCycle;

    public List<CycleSettingsSO> _listCycleSettings;

    [SerializeField] private GameObject _restartCyclePanel;
    [SerializeField] private GameObject _nextCyclePanel;

    [SerializeField] private GameObject _canvas;

    public int _amountCatchedHumans;
    public int _amountDisorderlyConduct;
    [SerializeField] private TextMeshProUGUI _catcherText;
    [SerializeField] private TextMeshProUGUI _disorderlyText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(_canvas);
            return;
        }

        Destroy(gameObject);
        Destroy(_canvas);
    }

    private void Start()
    {
        _catcherText.text = "0 / " + _listCycleSettings[_currentCycle]._humanCatchedAmount;
        _disorderlyText.text = "0 / " + _listCycleSettings[_currentCycle]._disorderlyAmount;
    }

    public void LaunchNextCycle()
    {
        _currentCycle++;
        Debug.Log(_currentCycle);
        SceneManager.LoadSceneAsync(0);
        _nextCyclePanel.SetActive(false);

        _amountCatchedHumans = 0;
        _amountDisorderlyConduct = 0;
        Time.timeScale = 1;
        _catcherText.text = "0 / " + _listCycleSettings[_currentCycle]._humanCatchedAmount;
        _disorderlyText.text = "0 / " + _listCycleSettings[_currentCycle]._disorderlyAmount;
    }

    public void RestartCycle()
    {
        Debug.Log(_currentCycle);
        SceneManager.LoadSceneAsync(0);
        _restartCyclePanel.SetActive(false);

        _amountCatchedHumans = 0;
        _amountDisorderlyConduct = 0;
        Time.timeScale = 1;
        _catcherText.text = "0 / " + _listCycleSettings[_currentCycle]._humanCatchedAmount;
        _disorderlyText.text = "0 / " + _listCycleSettings[_currentCycle]._disorderlyAmount;
    }

    public void ActivateRestartPanel()
    {
        _restartCyclePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ActivateNextPanel()
    {
        _nextCyclePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void AddCatchedHumans()
    {
        _amountCatchedHumans++;
        _catcherText.text = _amountCatchedHumans.ToString() + " / " + _listCycleSettings[_currentCycle]._humanCatchedAmount;
        if (_amountCatchedHumans >= _listCycleSettings[_currentCycle]._humanCatchedAmount)
        {
            ActivateNextPanel();
        }
    }

    public void AddDisorderlyConduct()
    {
        _amountDisorderlyConduct++;
        _disorderlyText.text = _amountDisorderlyConduct.ToString() + " / " + _listCycleSettings[_currentCycle]._disorderlyAmount;
        if (_amountDisorderlyConduct >= _listCycleSettings[_currentCycle]._disorderlyAmount)
        {
            ActivateRestartPanel();
        }
    }
}