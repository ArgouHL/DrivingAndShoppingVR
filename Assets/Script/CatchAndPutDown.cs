using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchAndPutDown : MonoBehaviour
{
    
    //[SerializeField] private GameObject targetGood;
    [SerializeField] private ShoppingPlayerControl shoppingPlayerControl;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject catchGood;
    [SerializeField] private GameObject targetGood;


    private void Awake()
    {
        player = GameObject.Find("Player");
        shoppingPlayerControl = player.GetComponent<ShoppingPlayerControl>();
        transform.parent = player.transform;
        shoppingPlayerControl.GotoFirstPoint();
        targetGood = shoppingPlayerControl.GetTarget();
       
    }



    private void Start()
    {
        StartCoroutine("CatchGoodCoroutine");
    }

    private void CatchGood()
    {
        if (catchGood != null || targetGood == null)
            return;
        

        if (Vector3.Distance(transform.position, targetGood.transform.position) <0.3f)
        {
            catchGood = targetGood;
            catchGood.transform.parent = transform;
            catchGood.transform.localPosition = Vector3.zero;
            Destroy(catchGood.GetComponent<Outline>());
        }

    }


    private void OnTriggerEnter(Collider collider)
    {
        print("hit");
        print(collider.gameObject.tag);
        if (collider.gameObject.tag == "Cart" && catchGood != null)
        {
            print("down");
            catchGood.transform.parent = player.transform;
            catchGood.AddComponent<MeshCollider>().convex= true;
            catchGood.AddComponent<Rigidbody>();
            shoppingPlayerControl.NextPoint();
            targetGood = shoppingPlayerControl.GetTarget();
            catchGood = null;
        }
    }

    private IEnumerator CatchGoodCoroutine()
    {
        while(!ShoppingGameSystem.isGetGameEnd)
        {
            CatchGood();
            yield return null;
        }
    }

}
