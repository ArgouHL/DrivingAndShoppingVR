using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowFps : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text text2;
    public float deltaTime;

    private void Start()
    {
        InvokeRepeating("UpdateFPS", 0, 0.2f);
    }


    void UpdateFPS()
    {

        text.text = Mathf.Ceil(1 / Time.deltaTime).ToString();
        text2.text = "Vsync : " + QualitySettings.vSyncCount.ToString() + ", target FPS : "+Application.targetFrameRate.ToString();
    }
}

