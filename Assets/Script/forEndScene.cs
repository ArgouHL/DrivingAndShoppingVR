using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class forEndScene : MonoBehaviour
{

    [SerializeField]
    private Image fadeImage;
    [SerializeField]
    private CanvasGroup fade;
    void Start()
    {
        DrivingGameSystem.GameStart();
        StartCoroutine("EndFade");

    }

    private IEnumerator EndFade()
    {
        
       yield return new WaitForSeconds(6);
        fadeImage.color = Color.white;
        float time = 0f;
        while (time < 4)
        {
            fade.alpha = Mathf.Lerp(0, 1, time / 4);
            time += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(4);

    }
}
