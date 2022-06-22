using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tiempo : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private float tiempoActual;
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        tiempoActual= 2* Time.time;
        textMesh.text = tiempoActual.ToString("0.0");
    }
}
