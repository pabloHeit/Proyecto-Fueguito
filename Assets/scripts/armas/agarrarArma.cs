using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrarArma : MonoBehaviour
{
    [Tooltip("0 = espada : 1 = rifle : 2 = lanza-granadas")]
    [SerializeField] private int nroActivador;
    private bool EnRango;
    [SerializeField] private bool ArmaComprable;
    private controlArmas controlArmas;

    private void Start() {
        controlArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<controlArmas>();        
    }

    void Update()
    {
        if (!ArmaComprable
            && EnRango
            && Input.GetKeyDown(KeyCode.E)){
            agarrar();
        }
    }
    public void agarrar()
    {
        controlArmas.activarArmas(nroActivador);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player"){
            EnRango = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            EnRango = false;
        }
    }
}
