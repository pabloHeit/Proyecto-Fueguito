using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodigoVolumen : MonoBehaviour
{

    public Slider slider;
    public float sliderValue;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenaudio", 0.5f);
        AudioListener.volume = slider.value;
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenaudio",sliderValue);
        AudioListener.volume = slider.value; 
    }
}
