using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingPlayerControl : MonoBehaviour
{

    [SerializeField] private float moveTime;
    public List<ShelfTarget> Shelfs;


    [SerializeField] private int targetCount = 0;
    [SerializeField] private int pointCount = 0;

    public void Awake()
    {

    }

    public void GotoFirstPoint()
    {
        StartCoroutine(MoveToNextPoint(targetCount));
    }


    public void NextPoint()
    {
        print("points.Count");
        int previousPointCount = pointCount;


        if (pointCount >= Shelfs.Count)
        {
            print("GameENd");
            ShoppingGameSystem.GoToCasher();
            return;
        }
        if (ShoppingGameSystem.isGetGameEnd)
        {
            return;
        }

        pointCount++;
        targetCount++;
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
