using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingPlayerControl : MonoBehaviour
{
   public List<Transform> points;
    public List<GameObject> targets;

    private int targetCount = 0;
    private int pointCount = 0;






    public void NextPoint()
    {

        int previousPointCount = pointCount;
        pointCount++;
        targetCount ++;
        if(pointCount >= points.Count)
        {
            print("GameENd");
            return;
        }    
        pointCount ++;
        StartCoroutine(MoveToNextPoint(previousPointCount, targetCount));
    }




    private IEnumerator MoveToNextPoint(int org,int next)
    {
        yield return new WaitForSeconds(0.5f);
        float time = 0;
        float duration = 2;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(points[org].position, points[next].position, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = points[next].position;
       

    }


    public GameObject GetTarget()
    {
        if (targetCount >= targets.Count)
            return null;
        print(targetCount);
        return targets[targetCount];
    }

}
