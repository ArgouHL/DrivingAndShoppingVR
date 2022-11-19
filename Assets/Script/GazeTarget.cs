using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;


public class GazeTarget : MonoBehaviour
{
    [SerializeField] private UnityEvent gazeEnter;
    [SerializeField] private UnityEvent gazeExit;
    [SerializeField] private UnityEvent gazeDone;


    public void GazeEnter()
    {
        gazeEnter.Invoke();
    }

    public void GazeExit()
    {
        gazeExit.Invoke();
    }


    public void GazeDone()
    {
        gazeDone.Invoke();
    }

























}
