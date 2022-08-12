using UnityEngine;


public class MenuInicial : MonoBehaviour
{
    public void Jugar()
    {
        levelLoader.LoadLevel("SampleScene");
    }
    
    public void Salir()
    {
        Application.Quit();
    }
}
