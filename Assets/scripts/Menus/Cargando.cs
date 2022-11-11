using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cargando : MonoBehaviour
{
    private void Start() {

        GameManager.Instance.UpdateGameState(GameState.Cargando);

        string leveToLoad = levelLoader.nextLevel;
        StartCoroutine(this.MakeTheLoad(leveToLoad));
    }
    
    IEnumerator MakeTheLoad(string level)
    {
        if (level == "MenuPrincipal")
        {
            GameManager.Instance.UpdateGameState(GameState.MenuPrincipal);
        }
        
        yield return new WaitForSeconds(1f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        while (operation.isDone == false)
        {
            Destroy(this);
            yield return null;
        }
    }
}
