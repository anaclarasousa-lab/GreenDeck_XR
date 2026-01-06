using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable))]
public class GravityOnGrab : MonoBehaviour
{
    private Rigidbody rb;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        // 1. Al inicio, nos aseguramos de que no caiga
        rb.useGravity = false;
        rb.isKinematic = true;

        // 2. Nos suscribimos al evento cuando el usuario agarra el objeto
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // 3. Activamos la f�sica real
        rb.useGravity = true;
        rb.isKinematic = false;

        // Opcional: Desuscribirse para que ya se quede con f�sica para siempre
        grabInteractable.selectEntered.RemoveListener(OnGrab);

        Debug.Log($"Gravedad activada para: {gameObject.name}");
    }

    private void OnDestroy()
    {
        // Limpieza de seguridad
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }
}
