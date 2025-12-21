using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketPhysicsFix : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

    private void OnEnable()
    {
        socket.selectEntered.AddListener(OnObjectInserted);
        socket.selectExited.AddListener(OnObjectRemoved);
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnObjectInserted);
        socket.selectExited.RemoveListener(OnObjectRemoved);
    }

    private void OnObjectInserted(SelectEnterEventArgs args)
    {
        Rigidbody rb = args.interactableObject.transform.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnObjectRemoved(SelectExitEventArgs args)
    {
        Rigidbody rb = args.interactableObject.transform.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}


