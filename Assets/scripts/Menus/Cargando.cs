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

    void OnDestroy(){
        GameManager.Instance.UpdateGameState(GameState.EnJuego);
    }

    IEnumerator MakeTheLoad(string level)
    {
        
        yield return new WaitForSeconds(1f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        while (operation.isDone == false)
        {
            Destroy(this);
            yield return null;
        }
    }
}
