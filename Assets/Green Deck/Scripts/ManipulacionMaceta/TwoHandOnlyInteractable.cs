using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandOnlyInteractable : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;
    public Rigidbody rb;

    void Awake()
    {
        grab.selectEntered.AddListener(OnSelectEntered);
        grab.selectExited.AddListener(OnSelectExited);

        rb.isKinematic = false;
    }

    void OnDestroy()
    {
        grab.selectEntered.RemoveListener(OnSelectEntered);
        grab.selectExited.RemoveListener(OnSelectExited);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Solo permitir mover con 2 manos
        if (grab.interactorsSelecting.Count < 2)
        {
            rb.isKinematic = true; // bloquea movimiento
        }
        else
        {
            rb.isKinematic = false; // permite mover
        }
    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        // Si al soltar queda menos de 2 manos → soltar completamente
        if (grab.interactorsSelecting.Count < 2)
        {
            // Forzar que cualquier mano restante suelte
            foreach (var interactor in grab.interactorsSelecting)
            {
                grab.interactionManager.SelectExit(interactor, grab);
            }

            // Activar física
            rb.isKinematic = false;
        }
    }
}