using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private SceceLoad sceceLoad;
   

    [SerializeField]
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

    [SerializeField] private CanvasGroup fade;
    [SerializeField] private float fadeTime = 2;

    public void Awake()
    {
        StartCoroutine("FadeIn");
    }

    public void EndFade()
    {
        StartCoroutine("FadeOut");
    }




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
        print("speedup");

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


    public void SlowDoneAndStop(Transform endPoint)
    {
        StartCoroutine("SlowDown", endPoint);
    }

    private IEnumerator SlowDown(Transform endPoint)
    {
        StartCoroutine(ToRight());
        while (endPoint.position.z > 80)
        {
            yield return null;
        }
        while (endPoint.position.z >0.5f)
        {
            speed = Mathf.Lerp(0, maxSpeed, endPoint.position.z / 80);
            yield return null;
        }
        while (speed>0)
        {
            speed -= 5*Time.deltaTime ;
            yield return null;
        }
        speed = 0;
        yield return FadeOut();
        sceceLoad.Game2();


    }

    private IEnumerator ToRight()
    {
        float time = 0;
        float duration = 5;
        Vector3 orgPos = transform.position;
        while (time < duration)
        {
            transform.position = new Vector3(Mathf.Lerp(orgPos.x, 3, time / duration), transform.position.y, transform.position.z);
            time += Time.deltaTime;
            yield return null;
        }
    }


    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1);
        float time = 0f;

        while (time < fadeTime)
        {
            fade.alpha = Mathf.Lerp(1, 0, time / fadeTime);
           time += Time.deltaTime;
            yield return null;
        }



    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1);
        float time = 0f;
        while (time < fadeTime)
        {
            fade.alpha = Mathf.Lerp(0, 1, time / fadeTime);
            time += Time.deltaTime;
            yield return null;
        }



    }

}
