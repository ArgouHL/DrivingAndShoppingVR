
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSpawnAndDetection : MonoBehaviour
{

    private int obsCount = 0;

    [SerializeField] private GameObject obs;
    [SerializeField] private GameObject shop;
    [SerializeField] private PlayerControl playerControl;
    private GameObject nowObs;

    private void Awake()
    {
        SpawnObs(3);

    }

   
    private void Update()
    {
      
        check(nowObs);
    }

    private void SpawnObs(float xPos)
    {
        if (obsCount > 20)
        {
            gameStop();
            return;
        }
        print("spawn");
          
        obsCount++;
        GameObject obsObject = Instantiate(obs, new Vector3(xPos, 0f, 100f), Quaternion.identity);
        obsObject.AddComponent<ObsMove>().SetPlayerControl(playerControl);
        nowObs = obsObject;
    }

    private void gameStop()
    {
        DrivingGameSystem.isGameEnd = true;
        shop.transform.position = new Vector3(10, 3, 200);
        shop.AddComponent<ShopMove>().playerControl = playerControl;
        playerControl.SlowDoneAndStop(shop);

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
