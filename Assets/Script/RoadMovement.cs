using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;
  
  

   


    


    private void Update()
    {
        transform.position -= new Vector3(0, 0, playerControl.GetPlayerSpeed()) *Time.deltaTime; 
    }

    private void LateUpdate()
    {
        if(transform.position.z <=-200)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 200);
           
        }
    }
}
