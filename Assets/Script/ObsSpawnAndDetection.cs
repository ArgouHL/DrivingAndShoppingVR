
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSpawnAndDetection : MonoBehaviour
{
    private bool endStreetSpawn =false;
    private int obsCount = 0;
    [SerializeField] private int obsNumbers=1;
    [SerializeField] private GameObject endStreet;





   [SerializeField] private GameObject[] obs;
    [SerializeField] private Transform endPoint;
    [SerializeField] private PlayerControl playerControl;
    private GameObject nowObs;

    private void Awake()
    {
        SpawnObs(-3);

    }

   
    private void Update()
    {
      
        check(nowObs);
    }

    internal void streetTeleport(GameObject street,Vector3 orgPosition)
    {
        if(DrivingGameSystem.isGameEnd&&!endStreetSpawn)
        {
            endStreet.transform.position = new Vector3(0, 0, 195);
            street.SetActive(false);
            endStreet.SetActive(true);
            street = endStreet;
            endStreetSpawn = true;
            playerControl.SlowDoneAndStop(endPoint);
            
        }
        else
        {
            street.transform.position = orgPosition + new Vector3(0, 0, 395); 
        }
       
        street.GetComponent<RoadMovement>().check = true;
    }

    private void SpawnObs(float xPos)
    {
        if (obsCount > obsNumbers)
        {
            gameStop();
            return;
        }
        print("spawn");
          
        obsCount++;
        GameObject obsObject = Instantiate(obs[Random.Range(0,obs.Length)], new Vector3(xPos, 0f, 100f), Quaternion.identity);
        obsObject.AddComponent<ObsMove>().SetPlayerControl(playerControl);
        nowObs = obsObject;
    }

    private void gameStop()
    {
        DrivingGameSystem.isGameEnd = true;
      
    }

    private void check(GameObject o)
    {
        if (DrivingGameSystem.isGameEnd)
            return;

        if (o.transform.position.z < -0.5f)
        {
            SpawnObs(RndOgsPos());
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

    private float RndOgsPos()
    {
        float x = Random.Range(0f, 1f) > 0.5f ? -3 : 3;
        print(x);
        return x;
    }

  


}
