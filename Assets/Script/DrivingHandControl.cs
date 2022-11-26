using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrivingHandControl : MonoBehaviour
{
    [SerializeField] private GameObject steering;
    [SerializeField] private PlayerControl playerControl;
    private Vector3 rotate = Vector3.zero;
    [SerializeField] private Quaternion steeringOrgRotate;


    private void Awake()
    {
        steering = GameObject.Find("Steering");
        playerControl = GameObject.Find("PlayerOrg").GetComponent< PlayerControl>();
        transform.parent = GameObject.Find("PlayerOrg").transform;
        steeringOrgRotate = steering.transform.rotation;

    }

    private void Update()
    {

       


        float _rotate = transform.rotation.eulerAngles.x-270;
        //print("Be "+_rotate);
        _rotate = (transform.rotation.y < 0) ? _rotate  : -_rotate ;
        //print("AF " + _rotate);
        if (Vector3.Distance(transform.position, steering.transform.position) < 0.5)
        {
           
            steering.transform.rotation = Quaternion.Euler(new Vector3(steeringOrgRotate.eulerAngles.x, steeringOrgRotate.eulerAngles.y, _rotate));
        }
        else
            steering.transform.rotation = steeringOrgRotate;
    }
}
