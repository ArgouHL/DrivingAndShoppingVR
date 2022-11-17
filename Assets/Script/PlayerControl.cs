using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{



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
        
        speed -= deceleratSpeed * Time.deltaTime*Mathf.Lerp (10f, 1 , (distance-2)/20);
         //print("slow");
        if (speed < 0)
        {
            speed = 0;
        }

    }


    public void SpeedUp()
    {
        if(!DrivingGameSystem.isGameStart)
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
        float _rotate = steering.transform.localRotation.eulerAngles.z;
        _rotate = (_rotate > 180) ? _rotate - 360 : _rotate;
        //print("R" + _rotate);

        if (-_rotate > 0 && transform.position.x >= 3 || -_rotate < 0 && transform.position.x <= -3)
            return Vector3.zero;

        Vector3 _move = new Vector3(-_rotate, 0, 0) * rotateSpeed;
        //print(_move);
        return _move;
    }





    public float GetPlayerSpeed()
    {

        return speed * speedFactor;
    }

   



}
