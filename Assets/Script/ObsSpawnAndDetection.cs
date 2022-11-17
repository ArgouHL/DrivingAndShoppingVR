using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSpawnAndDetection : MonoBehaviour
{
    [SerializeField] private GameObject obs;

    [SerializeField] private PlayerControl playerControl;
    private GameObject nowObs;

    private void Awake()
    {
        SpawnObs(-3f);

    }




    private void Update()
    {
      


        check(nowObs);
    }

    private void SpawnObs(float xPos)
    {
        GameObject obsObject = Instantiate(obs, new Vector3(xPos, 0f, 100f), Quaternion.identity);
        obsObject.AddComponent<ObsMove>().SetPlayerControl(playerControl);
        nowObs = obsObject;
    }


    private void check(GameObject o)
    {
        if (o.transform.position.z < -0.5f)
        {
            SpawnObs(-3);
        }
        else if  (o.transform.position.z<30 && o.transform.position.x *transform.position.x >0 )
        {
            playerControl.SpeedDown(o.transform.position.z);




        }
        else
        {
            playerControl.SpeedUp();
        }


    }



}
