using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class controladorPuntos : MonoBehaviour
{
   public float puntos;
   private TextMeshProUGUI textMesh;

   private void Start()
   {
       textMesh = GetComponent<TextMeshProUGUI>();
   }

   public void SumarPuntos(float puntosEntrada){
       puntos += puntosEntrada;
       modificarPuntos(puntos);
    }

   public void RestarPuntos(float puntosEntrada){
       puntos -= puntosEntrada;
       modificarPuntos(puntos);       
    }

   private void modificarPuntos(float puntos)
   {
       textMesh.text = "$" + puntos.ToString("0");
   }
}
