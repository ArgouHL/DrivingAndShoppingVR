using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowFps : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text text2;
    public float deltaTime;

    void Update()
    {

        text.text = Mathf.Ceil(1 / Time.deltaTime).ToString();
        text2.text = "Vsync : " + QualitySettings.vSyncCount.ToString() + ", target FPS : "+Application.targetFrameRate.ToString();
    }
}

