using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guitarra : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    // SpriteRenderer sprite;

    [SerializeField] private AudioClip cancion;
    private bool tocando = false;

    private void Start()  
    {
        // sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = cancion;
        animator.speed = 0;
    }

    void Update()
    {
        if (GameManager.EnableInput) {
            bool tocar = Input.GetButton("Fire1");
            
            if (tocar && !tocando) {
                tocarCancion() ;
            }
            else if(!tocar && tocando) {
                pausarCancion();
            }
        }
    }

    private void tocarCancion()
    {
        animator.speed = 1;
        tocando = true;
        audioSource.Play();
    }

    private void pausarCancion()
    {
        animator.speed = 0;
        tocando = false;
        audioSource.Pause();
    }
}
