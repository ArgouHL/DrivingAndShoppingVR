using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
    

    private LineRenderer lineRenderer;

    private Camera pointer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        pointer = GetComponent<Camera>();
    }



    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);


        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + transform.forward * 500);

        //PointerEventData centreData = new PointerEventData(EventSystem.current);
        //centreData.position = transform.position;

        //List<RaycastResult> results = new List<RaycastResult>();
        //EventSystem.current.RaycastAll(centreData, results);



        //if (results.Count > 0)
        //    print("hit");

       



    }


   
}
