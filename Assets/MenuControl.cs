using UnityEngine;
using UnityEngine.InputSystem;

public class MenuControl: MonoBehaviour
{
    public GameObject menuPanel; // Arrastra tu Canvas aquí
    public InputActionReference openMenuAction; // El botón del mando

    [Header("Sound")]

    public AudioClip popUp; 

    private void Awake() {
        openMenuAction.action.Enable();
        openMenuAction.action.performed += ToggleMenu;
        InputSystem.onDeviceChange += OnDeviceChange;
    }
    private void OnDestroy() {
        openMenuAction.action.Disable();
        openMenuAction.action.performed -= ToggleMenu;
        InputSystem.onDeviceChange -= OnDeviceChange;
    }
    private void ToggleMenu(InputAction.CallbackContext context)
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        if (popUp != null)
        {
         AudioSource.PlayClipAtPoint(popUp, Camera.main.transform.position);
        }
    }
    private void OnDeviceChange (InputDevice device, InputDeviceChange change)
    {
        switch(change)
        {
            case InputDeviceChange.Disconnected:
                openMenuAction.action.Disable();
                openMenuAction.action.performed -= ToggleMenu;
                break;
            case InputDeviceChange.Reconnected:
                openMenuAction.action.Enable();
                openMenuAction.action.performed += ToggleMenu;
                break;

        }
    }
}
