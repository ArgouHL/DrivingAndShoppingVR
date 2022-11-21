using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private SceceLoad sceceLoad;


    private float maxSpeed = 30;
    [SerializeField]
    private float speedFactor = 1;
    [SerializeField]
    private float rotateSpeed = 10;
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private float accelerate = 30;
    [SerializeField]
    private float deceleratSpeed = 15;



    [SerializeField] private GameObject steering;


    //0 is left ,1 is right 
    public static int playerLine = 0;



    private void Update()
    {


        transform.position += horizontalMove() * Time.deltaTime * 0.01f;


    }


    public void SpeedDown(float distance)
    {

        if (speed <= 0)
            return;

        speed -= deceleratSpeed * Time.deltaTime * Mathf.Lerp(10f, 1, (distance - 2) / 20);
        //print("slow");
        if (speed < 0)
        {
            speed = 0;
        }

    }


    public void SpeedUp()
    {
        if (!DrivingGameSystem.isGameStart || DrivingGameSystem.isGameEnd)
            return;
        if (speed > maxSpeed)
            return;
        speed += accelerate * Time.deltaTime;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

    }

    public Vector3 horizontalMove()
    {
        if (!DrivingGameSystem.isGameStart || DrivingGameSystem.isGameEnd)
            return Vector3.zero;

        float _rotate = steering.transform.localRotation.eulerAngles.z;
        _rotate = (_rotate > 180) ? _rotate - 360 : _rotate;
        //print("R" + _rotate);

        if (-_rotate > 0 && transform.position.x >= 3.4f || -_rotate < 0 && transform.position.x <= -3.4f)
            return Vector3.zero;

        Vector3 _move = new Vector3(-_rotate, 0, 0) * rotateSpeed;
        //print(_move);
        return _move;
    }





    public float GetPlayerSpeed()
    {
        return speed * speedFactor;
    }


    public void SlowDoneAndStop(GameObject shop)
    {
        StartCoroutine("SlowDown", shop);
    }

    private IEnumerator SlowDown(GameObject shop)
    {
        float time = 0;
        float duration = 2;
        Vector3 orgPos = transform.position;
        while (time < duration)
        {
            transform.position = new Vector3(Mathf.Lerp(orgPos.x, 3, time / duration), transform.position.y, transform.position.z);
            time += Time.deltaTime;
            yield return null;
        }
        while (shop.transform.position.z > 30)
        {
            yield return null;
        }
        while (shop.transform.position.z >0.5f)
        {
            speed = Mathf.Lerp(1, maxSpeed, shop.transform.position.z / 30);
            yield return null;
        }
        while (speed>0)
        {
            speed -= 5*Time.deltaTime ;
            yield return null;
        }
        speed = 0;
        yield return new WaitForSeconds(1);
        sceceLoad.Game2();


    }



}
