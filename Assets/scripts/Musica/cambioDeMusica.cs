using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioDeMusica : MonoBehaviour
{
    AudioSource AudioSource;
    [SerializeField] private AudioClip walkingSong;

    [SerializeField] private AudioClip fightingSong;
    
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void ReproducirMusica_Tranqui() {
        if (AudioSource.clip != walkingSong)
        {
            AudioSource.clip = walkingSong;
            AudioSource.Play();            
        }
    }

    public void ReproducirMusica_Pelea() {
        if (AudioSource.clip != fightingSong)
        {
            AudioSource.clip = fightingSong;
            AudioSource.Play();
        }
    }
}