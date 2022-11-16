using Input;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private static PlayerInput _input;

    public static PlayerInput Singletone => _input;

    private void Awake()
    {
        if (_input == null)
        {
            _input = new PlayerInput();
            _input.WorldMovement.Enable();
        }
    }

    private void OnDisable()
    {
        _input = null;
    }
}
