using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenManager : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio",0.5f);
        AudioListener.volume = slider.value;
    }
    void Update()
    {
        sliderValue = slider.value;
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio",sliderValue);
        AudioListener.volume = slider.value;
        
    }
}