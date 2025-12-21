using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager: MonoBehaviour
{
    public GameObject menuObject; // Arrastra tu Canvas aquí
    public InputActionProperty menuButton; // El botón del mando

    void Update()
    {
        // Detecta si el botón fue presionado en este frame
        if (menuButton.action.WasPressedThisFrame())
        {
            bool isActive = !menuObject.activeSelf;
            menuObject.SetActive(isActive);

            if (isActive) {
                // Posiciona el menú frente al jugador si lo deseas
                PositionMenu();
            }
        }
    }

    void PositionMenu() {
        // Opcional: Hace que el menú aparezca frente a la cámara
        Transform cameraTransform = Camera.main.transform;
        menuObject.transform.position = cameraTransform.position + cameraTransform.forward * 2f;
        menuObject.transform.LookAt(new Vector3(cameraTransform.position.x, menuObject.transform.position.y, cameraTransform.position.z));
        menuObject.transform.forward *= -1; // Corrige la rotación para que mire al usuario
    }
}


