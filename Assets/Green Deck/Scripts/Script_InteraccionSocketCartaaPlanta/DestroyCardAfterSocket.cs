using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DestroyCardAfterSocket : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;
    private bool removedFromSocket = false;

    void Awake()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grab.selectExited.AddListener(OnSelectExited);
    }

    // Llamado SOLO cuando sale del socket
    public void MarkRemovedFromSocket()
    {
        removedFromSocket = true;
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        // ⚠️ IMPORTANTE:
        // Si el que deja de seleccionar es un SOCKET, NO destruir
        if (args.interactorObject is UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor)
            return;

        // Solo destruir si antes salió de un socket
        if (removedFromSocket)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        grab.selectExited.RemoveListener(OnSelectExited);
    }
}
