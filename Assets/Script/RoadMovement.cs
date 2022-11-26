using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private ObsSpawnAndDetection obsSpawnAndDetection;
    [SerializeField] public bool check;







    private void Update()
    {
        transform.position -= new Vector3(0, 0, playerControl.GetPlayerSpeed()) *Time.deltaTime; 
    }

    private void LateUpdate()
    {

        if (transform.position.z <= -200&& check)
        {
            check = false;
            obsSpawnAndDetection.streetTeleport(gameObject);
            

        }
    }
}
