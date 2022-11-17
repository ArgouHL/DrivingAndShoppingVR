using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugLog : MonoBehaviour
{
    [SerializeField] private TMP_Text debug;
    [SerializeField] private TMP_Text debug1;
    [SerializeField] private GameObject xr;

    private void Update()
    {
        debug.text = transform.position.ToString();
        debug1.text = "XR: " + xr.transform.position.ToString();
    }
}
