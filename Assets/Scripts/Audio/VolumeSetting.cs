using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private Slider soundSlider;


    private void Start()
    {
        SetMainVolume();
    }
    public void SetMainVolume()
    {
        float volume = soundSlider.value;
        mainMixer.SetFloat("MainVolume", Mathf.Log10(volume)*20);
    }
}
