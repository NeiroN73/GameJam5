using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class ChangeAudio : MonoBehaviour
{
    public AudioMixer aMixerAudio;
    public string volumeParametr = "MusicBild";//MusicBild
    public const float _multiplier = 20;
    public Slider slider;

    private void Awake()
    {
        slider.onValueChanged.AddListener(ChangeValue);
    }
    public void ChangeValue(float values)
    {
        var voluemeValue = Mathf.Log10(slider.value) * _multiplier;
        aMixerAudio.SetFloat(volumeParametr, voluemeValue);
    }
}
