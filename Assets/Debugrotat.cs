using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Debugrotat : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text text2;
    public GameObject wheel;
    public GameObject hand;
    private void Update()
    {
        text.text = wheel.transform.localRotation.ToString() ;
        text2.text = hand.transform.localRotation.ToString();
    }

}
