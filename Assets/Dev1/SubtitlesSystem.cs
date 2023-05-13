using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitlesSystem : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _tmpro;

    [SerializeField] private List<string> _text;
    [SerializeField] private float _textSpeed;

    private void Start()
    {
        _panel.SetActive(false);
        //StartCoroutine(OutputText());
    }

    IEnumerator OutputText()
    {
        foreach (char symbol in _text[0])
        {
            _tmpro.text += symbol.ToString();
            yield return new WaitForSeconds(_textSpeed);
        }
    }
}
