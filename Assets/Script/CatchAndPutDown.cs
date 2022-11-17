using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchAndPutDown : MonoBehaviour
{
    public GameObject targetGood;
    [SerializeField] private GameObject catchGood;
    
    private void Update()
    {
        CatchGood();
    }

    private void CatchGood()
    {
        if (catchGood != null)
            return;
        if (Vector3.Distance(transform.position, targetGood.transform.position) <0.3f)
        {
            catchGood = targetGood;
            catchGood.transform.parent = transform;
            catchGood.transform.localPosition = Vector3.zero;
            Destroy(catchGood.GetComponent<Rigidbody>());
        }

    }


    private void OnTriggerEnter(Collider collider)
    {
        print("hit");
        print(collider.gameObject.tag);
        if (collider.gameObject.tag == "Cart")
        {
            print("down");
            catchGood.transform.parent = null;
            catchGood.AddComponent<Rigidbody>();
            //catchGood = null;
        }
    }

}
