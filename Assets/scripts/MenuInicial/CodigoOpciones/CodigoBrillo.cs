using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodigoBrillo : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelBrillo;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brillo", sliderValue);
        panelBrillo.color = new Color(0, 0, 0, (-slider.value + 0.9f));
    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);

        panelBrillo.color = new Color(0, 0 ,0, (-slider.value + 0.9f));
    }
}
