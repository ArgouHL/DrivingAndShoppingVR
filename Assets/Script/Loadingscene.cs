using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadingscene : MonoBehaviour
{
    private AsyncOperation async;
    // Start is called before the first frame update
    void Start()
    {
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
        StartCoroutine("EndLoad");
    }

    private IEnumerator EndLoad()
    {
        yield return new WaitForSeconds(10);
        async.allowSceneActivation = true;
    }
}
