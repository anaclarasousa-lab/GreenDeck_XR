using UnityEngine;
using UnityEngine.InputSystem;

public class MenuToggle : MonoBehaviour
{
    public GameObject menuObject; // Tu Canvas con el Lazy Follow
    public InputActionProperty toggleButton; // La referencia al botón del mando


    void Update()
    {
        // Verifica si el botón fue presionado en este frame
        if (toggleButton.action.WasPressedThisFrame())
        {
            // Invierte el estado actual (si está activo lo apaga, y viceversa)
            bool isActive = !menuObject.activeSelf;
            menuObject.SetActive(isActive);
        }
    }
}