using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketKinematicController : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socketInteractor; // Asigna el socket en el inspector
    private Rigidbody socketRigidbody;

    private void Awake()
    {
        if (socketInteractor == null)
        {
            Debug.LogError("Asigna un XRSocketInteractor en el inspector.");
            return;
        }

        // Obtenemos el Rigidbody del objeto que tiene el socket
        socketRigidbody = GetComponent<Rigidbody>();
        if (socketRigidbody == null)
        {
            Debug.LogError("El objeto con el socket necesita un Rigidbody.");
        }

        // Registramos los eventos de selecci�n
        socketInteractor.selectEntered.AddListener(OnObjectPlacedInSocket);
        socketInteractor.selectExited.AddListener(OnObjectRemovedFromSocket);
    }

    private void OnDestroy()
    {
        // Quitamos los listeners
        socketInteractor.selectEntered.RemoveListener(OnObjectPlacedInSocket);
        socketInteractor.selectExited.RemoveListener(OnObjectRemovedFromSocket);
    }

    private void OnObjectPlacedInSocket(SelectEnterEventArgs args)
    {
        // Activar isKinematic en el socket
        if (socketRigidbody != null)
        {
            socketRigidbody.isKinematic = true;
        }

        // Activar isKinematic en el objeto que entra
        if (args.interactableObject.transform.TryGetComponent<Rigidbody>(out Rigidbody objectRb))
        {
            objectRb.isKinematic = true;
        }
    }

    private void OnObjectRemovedFromSocket(SelectExitEventArgs args)
    {
        // Desactivar isKinematic en el socket
        if (socketRigidbody != null)
        {
            socketRigidbody.isKinematic = false;
        }

        // Desactivar isKinematic en el objeto que sale
        if (args.interactableObject.transform.TryGetComponent<Rigidbody>(out Rigidbody objectRb))
        {
            objectRb.isKinematic = false;
        }
    }
}
