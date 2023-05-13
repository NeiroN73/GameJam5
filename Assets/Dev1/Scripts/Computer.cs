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

    private void Start()
    {
        _panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            StartCoroutine(OutputText(_text));
            _panel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _panel.SetActive(false);
    }

    private IEnumerator OutputText(List<string> text)
    {
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
    }

    private IEnumerator OutputText(string phrase)
    {
        foreach (char symbol in phrase)
        {
            _tmpro.text += symbol.ToString();
            yield return new WaitForSeconds(_textSpeed);
        }

        yield return new WaitForSeconds(1);
        _tmpro.text = "";

        _panel.SetActive(false);
    }

    public void WarningSignal(string nameZone)
    {
        _panel.SetActive(true);
        StartCoroutine(OutputText("Human detected in " + nameZone));
    }
}
