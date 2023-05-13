using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _startTime;
    private float _currentTime;
    private CycleSwitcher _cycleSwitcher;

    private void Start()
    {
        _currentTime = _startTime;
        _cycleSwitcher = CycleSwitcher.Instance;
    }

    private void Update()
    {
        if(_currentTime <= 0)
        {
            print("Человек сбежал!");
            _currentTime = 0;
            _cycleSwitcher.RestartCycle();
        }
        else
        {
            _currentTime -= Time.deltaTime;
        }

        _text.text = _currentTime.ToString("F2");
    }
}
