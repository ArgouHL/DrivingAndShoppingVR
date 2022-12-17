using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    private DrivingPlayer drivingPlayer;
    private void Awake()
    {
        drivingPlayer = new DrivingPlayer();
        
    }

    private void OnEnable()
    {
        drivingPlayer.Enable();
    }

    private void OnDisable()
    {
        if (drivingPlayer != null)
        drivingPlayer.Disable();
    }
    public Vector2 WASD()
    {
        return drivingPlayer.Player.Move.ReadValue<Vector2>();
    }
}
