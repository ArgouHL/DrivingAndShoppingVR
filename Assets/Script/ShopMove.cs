using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMove : MonoBehaviour
{
    public PlayerControl playerControl;
    

    private void Update()
    {
        transform.position -= new Vector3(0, 0, playerControl.GetPlayerSpeed()) * Time.deltaTime;
    }

}
