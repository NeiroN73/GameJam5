using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _tmpro;

    [SerializeField] private List<string> _text;
    [SerializeField] private float _textSpeed;

    private bool check;

    private int _nameZone;

    private void Start()
    {
        StartCoroutine(OutputText(_text));
        _panel.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            if(check)
            {
                _panel.SetActive(true);
                StartCoroutine(OutputText("Human detected in " + _nameZone));
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //_panel.SetActive(false);
    }

    private IEnumerator OutputText(List<string> text)
    {
        check = false;
        _tmpro.text = "";
        foreach (string phrase in text)
        {
            foreach (char symbol in phrase)
            {
                _tmpro.text += symbol.ToString();
                yield return new WaitForSeconds(_textSpeed);
            }

            yield return new WaitForSeconds(1);
            _tmpro.text = "";
        }

        _panel.SetActive(false);

        check = true;
    }

    private IEnumerator OutputText(string phrase)
    {
        _tmpro.text = "";
        foreach (char symbol in phrase)
        {
            _tmpro.text += symbol.ToString();
            yield return new WaitForSeconds(_textSpeed);
        }

        yield return new WaitForSeconds(1);
        _tmpro.text = "";

        _panel.SetActive(false);
    }

    public void WarningSignal(int nameZone)
    {
        _nameZone = nameZone;
    }
}