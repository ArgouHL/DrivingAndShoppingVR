using System;
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
    [SerializeField] private GameObject money;
    [SerializeField] private Transform moneyTarget;


    private void Awake()
    {
        

    }



    private void Start()
    {
        player = GameObject.Find("Player");
        shoppingPlayerControl = player.GetComponent<ShoppingPlayerControl>();

        transform.parent = player.transform;
        shoppingPlayerControl.GotoFirstPoint();
        targetGood = shoppingPlayerControl.GetTarget();
        moneyTarget = GameObject.Find("MoneyTarget").transform;

        StartCoroutine("CatchGoodCoroutine");
    }

    private void CatchGood()
    {
        if (catchGood != null || targetGood == null)
            return;


        if (Vector3.Distance(transform.position, targetGood.transform.position) < 0.3f)
        {
            shoppingPlayerControl.PlayCorrectSound();
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
        if (collider.gameObject.tag == "Cart" && catchGood != null && catchGood.gameObject.tag != "money")
        {
            print("down");
            catchGood.transform.parent = player.transform;
            catchGood.AddComponent<MeshCollider>().convex = true;
            catchGood.AddComponent<Rigidbody>();
            shoppingPlayerControl.NextPoint();
            targetGood = shoppingPlayerControl.GetTarget();
            catchGood = null;
        }

        if (collider.gameObject.tag == "plate" && catchGood != null)
        {
            shoppingPlayerControl.PlayCorrectSound();
            print("moneydown");
            catchGood.transform.position = moneyTarget.transform.position;
            
            catchGood.transform.parent = moneyTarget.transform;
            catchGood.transform.localRotation = Quaternion.Euler(0, 90, 90);
            catchGood.transform.position = moneyTarget.transform.position;
            shoppingPlayerControl.EndFade();


        }



    }

    public void GetMoney()
    {
        GameObject newMoney = Instantiate(money, transform);
        newMoney.transform.localRotation = Quaternion.Euler(0, 90, 90);
        catchGood = newMoney;
    }

    private IEnumerator CatchGoodCoroutine()
    {
        yield return new WaitForSeconds(2);
        while (!ShoppingGameSystem.isGetGameEnd)
        {
            CatchGood();
            yield return null;
        }
    }

}
