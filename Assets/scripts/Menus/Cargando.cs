using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cargando : MonoBehaviour
{
    private void Start() {
        string leveToLoad = levelLoader.nextLevel;

        StartCoroutine(this.MakeTheLoad(leveToLoad));
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