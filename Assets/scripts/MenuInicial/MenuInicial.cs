using UnityEngine;


public class MenuInicial : MonoBehaviour
{
    public void Jugar()
    {
        levelLoader.LoadLevel("SampleScene");
    }
    
    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
