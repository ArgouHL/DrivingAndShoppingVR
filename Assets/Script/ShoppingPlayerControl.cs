using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShoppingPlayerControl : MonoBehaviour
{

    [SerializeField] private float moveTime;
    [SerializeField] private float fadeTime=1;
    public List<ShelfTarget> Shelfs;
    [SerializeField] private Transform player;
    [SerializeField] private Transform casherPoint;
    [SerializeField] private int targetCount = 0;
    [SerializeField] private int pointCount = 0;
    public CatchAndPutDown catchAndPutDown;
    [SerializeField] private CanvasGroup fade;

    public void Awake()
    {
        StartCoroutine("FadeIn");
    }

    public void EndFade()
    {
        StartCoroutine("FadeOut");
    }

    public void GotoFirstPoint()
    {

        StartCoroutine("MoveToNextPoint", targetCount);



    }


    public void NextPoint()
    {


        print("points.Count");
        int previousPointCount = pointCount;

        pointCount++;
        targetCount++;


        if (targetCount >= Shelfs.Count)
        {
            StartCoroutine("MoveToCasher");
            

        }
        else

            StartCoroutine(MoveToNextPoint(targetCount));
    }




    private IEnumerator MoveToNextPoint(int next)
    {
        yield return new WaitForSeconds(0.5f);
        var targetPos = GetCorriderPos(Shelfs[next]);
        float time = 0f;
        var orgPos = transform.position;
        while (time < moveTime)
        {



            transform.position = Vector3.Lerp(orgPos, targetPos, time / moveTime);
            time += Time.deltaTime;

            yield return null;
        }
        transform.position = targetPos;


    }


    private IEnumerator MoveToCasher()
    {
        yield return new WaitForSeconds(1);
        float time = 0f;
        var orgPos = transform.position;
        while (time < fadeTime)
        {
            fade.alpha = Mathf.Lerp(0, 1, time / fadeTime);



            time += Time.deltaTime;

            yield return null;
        }

        catchAndPutDown.GetMoney();
        transform.position = casherPoint.position;
        player.rotation = Quaternion.Euler(0, -90, 0);
        print("rotat");
        while (time > 0)
        {
            fade.alpha = Mathf.Lerp(0, 1, time / fadeTime);

            time -= Time.deltaTime;

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




    private Vector3 GetCorriderPos(ShelfTarget shelfTarget)
    {
        var _pos = Vector3.zero;
        var targerX = shelfTarget.gameObject.transform.position.x;
        _pos.x = targerX > 0 ? targerX - 0.5f : targerX + 0.5f;
        _pos.z = shelfTarget.gameObject.transform.position.z;


        return _pos;
    }

    public GameObject GetTarget()
    {
        if (targetCount >= Shelfs.Count)
            return null;
        print(targetCount);
        return Shelfs[targetCount].GetTarget();
    }

}
