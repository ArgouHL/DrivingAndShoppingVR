using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartMenu : MonoBehaviour
{

    private InputManager inputManager;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);

    }
    public void PlayGame2()
    {
        SceneManager.LoadScene(2);

    }


    private void Awake()
    {
        inputManager = InputManager.Instance;
    }
}
