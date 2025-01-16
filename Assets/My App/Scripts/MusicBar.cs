using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicBar : MonoBehaviour
{
    AudioSource audioSource;
    public Slider slider;
    public TMP_Text musicNameOnPlay;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        // Update the value of the slider to the current position of the audio clip
        slider.maxValue = audioSource.clip.length;
        slider.value = audioSource.time;
    }
    private void LateUpdate()
    {
        MusicNameOnPlay();
    }

    public void OnSliderValueChanged()
    {
        // Set the position of the audio clip to the value of the slider
        audioSource.time = slider.value;
    }

    public void MusicNameOnPlay()
    {
        musicNameOnPlay.text = audioSource.clip.name;
    }
}
