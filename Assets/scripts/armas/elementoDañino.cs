using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementoDañino : MonoBehaviour
{
    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {    
        if (other.CompareTag("Player"))
        {
            other.GetComponent<controladorVidas>().TomarDaño(10);
        }
    }

}
