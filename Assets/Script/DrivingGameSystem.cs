using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DrivingGameSystem : MonoBehaviour
{
    public static bool isGameStart = false;
    public static bool isGameEnd = false;


    private void Awake()
    {
        Initialization();
    }


    private void Initialization()
    {
        isGameEnd = false;
        isGameStart = false;
    }


    public static void GameStart()
    {
        isGameStart = true;

    }

    public static void GameEnd()
    {
        isGameEnd = true;

    }
}
