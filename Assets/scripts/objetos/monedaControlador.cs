using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monedaControlador : MonoBehaviour
{
    AudioSource audioSource;
    controladorPuntos controladorPuntos;

    [SerializeField] private float puntosGema;

    [SerializeField] private AudioClip[] sonidosMoneda;

    private void Start()
    {
        controladorPuntos =  GameObject.FindGameObjectWithTag("Puntaje").GetComponent<controladorPuntos>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int sonidoRandom =Random.Range(0, sonidosMoneda.Length);
            audioSource.PlayOneShot(sonidosMoneda[sonidoRandom]);
            controladorPuntos.SumarPuntos(puntosGema);
            Destroy(gameObject); 
        }            
    }    
}