using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingPlayerControl : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    public List<ShelfTarget> Shelfs;


    private int targetCount = 0;
    private int pointCount = 0;

    public void Awake()
    {
        
    }




    public void NextPoint()
    {
        print("points.Count");
        int previousPointCount = pointCount;
        
        
        if(pointCount >= Shelfs.Count)
        {
            print("GameENd");
            ShoppingGameSystem.GoToCasher();
            return;
        }
        if (ShoppingGameSystem.isGetGameEnd)
        {
            return;
        }
            
        pointCount ++;
        targetCount++;
        StartCoroutine(MoveToNextPoint(previousPointCount, targetCount));
    }




    private IEnumerator MoveToNextPoint(int org,int next)
    {
        yield return new WaitForSeconds(0.5f);
        
        while (transform.position.z < Shelfs[next].gameObject.transform.position.z)
        {

            transform.position = new Vector3(0, 0, transform.position.z + moveSpeed * Time.deltaTime);


                yield return null;
        }
        transform.position = new Vector3(0, 0, Shelfs[next].gameObject.transform.position.z);
       

    }


    public GameObject GetTarget()
    {
        if (targetCount >= Shelfs.Count)
            return null;
        print(targetCount);
        return Shelfs[targetCount].GetTarget();
    }

}
