using Dialog;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private Dialoger _dialoger;
    [SerializeField] private UnityEvent _gamePaused;
    [SerializeField] private UnityEvent _gameContinue;
    private bool _isPaused;

    private void OnEnable()
    {
        InputHandler.Singletone.PauseMenu.Enable();
        InputHandler.Singletone.PauseMenu.OpenClose.Enable();
        InputHandler.Singletone.PauseMenu.OpenClose.started += (InputAction.CallbackContext context) => OnMenuOpen();
    }

    private void OnDisable()
    {
        InputHandler.Singletone.PauseMenu.Disable();
        InputHandler.Singletone.PauseMenu.OpenClose.Disable();
        InputHandler.Singletone.PauseMenu.OpenClose.started -= (InputAction.CallbackContext context) => OnMenuOpen();
    }

    private void Start()
    {
        GameContinue();
    }

    public void OnMenuOpen()
    {
        _isPaused = _isPaused == false;
        _pauseMenu.SetActive(_isPaused);
        if (_isPaused)
        {
            GamePause();
            return;
        }
        GameContinue();
    }

    private void GamePause()
    {
        Time.timeScale = 0;
        InputHandler.Singletone.WorldMovement.Disable();
        InputHandler.Singletone.Dialog.Disable();
        _gamePaused.Invoke();
    }

    private void GameContinue()
    {
        InputHandler.Singletone.WorldMovement.Enable();
        if (_dialoger.InDialog)
        {
            InputHandler.Singletone.WorldMovement.Disable();
            InputHandler.Singletone.Dialog.Enable();
        }
        Time.timeScale = 1;
        _gameContinue.Invoke();
    }
}
