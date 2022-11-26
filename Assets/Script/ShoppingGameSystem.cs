using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingGameSystem : MonoBehaviour
{
   public  static bool isGetGameEnd = false;

    private void Awake()
    {
        Initialization();
    }



    private void Initialization()
    {
        isGetGameEnd = false;
    }

    public static void GoToCasher()
    {
        isGetGameEnd = true;

    }
}
