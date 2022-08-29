using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodigoVolumen : MonoBehaviour
{

    public Slider slider1;
    public Slider slider2;

    public float sliderValue;
    
    void Start()
    {
        slider1.value = PlayerPrefs.GetFloat("volumenaudio", 1f);        
        slider2.value = slider1.value;
        AudioListener.volume = slider1.value;
        AudioListener.volume = slider2.value;
    }

    public void ChangeSlider(float valor)
    {
        slider1.value = valor;
        slider2.value = valor;
        
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenaudio",sliderValue);
        AudioListener.volume = slider1.value; 
        AudioListener.volume = slider2.value; 
    }
}