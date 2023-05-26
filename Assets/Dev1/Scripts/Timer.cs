using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private float _currentTime;
    private CycleSwitcher _cycleSwitcher;

    private void Start()
    {
        _cycleSwitcher = CycleSwitcher.Instance;
        _currentTime = _cycleSwitcher._listCycleSettings[_cycleSwitcher._currentCycle]._time;
    }

    private void Update()
    {
        if(_currentTime <= 0)
        {
            print("Человек сбежал!");
            _currentTime = 0;
            _cycleSwitcher.ActivateRestartPanel();
        }
        else
        {
            _currentTime -= Time.deltaTime;
        }

        _text.text = _currentTime.ToString("F2");
    }
}
