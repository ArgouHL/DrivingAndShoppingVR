using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControlTest : MonoBehaviour
{
    private InputManager inputManager;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

}
