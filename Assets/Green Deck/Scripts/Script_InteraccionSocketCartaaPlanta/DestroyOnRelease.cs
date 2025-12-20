using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DestroyOnRelease : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;

    void Awake()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grab.selectExited.AddListener(OnReleased);
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        grab.selectExited.RemoveListener(OnReleased);
    }
}
