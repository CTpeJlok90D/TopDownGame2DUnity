using Input;
using UnityEngine;

public static class InputHandler
{
    private static PlayerInput _input;

    public static PlayerInput Singletone {
        get
        {
            if (_input == null)
            {
                _input = new PlayerInput();
                _input.WorldMovement.Enable();
            }
            return _input;
        }
    }
}
