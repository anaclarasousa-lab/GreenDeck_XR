using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TwoHandScaleInteractable : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public float minScale = 0.3f;
    public float maxScale = 2.0f;

    private Vector3 initialScale;
    private float initialHandsDistance;
    private bool isTwoHandScaling = false;

    void Awake()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        if (grabInteractable.interactorsSelecting.Count == 2)
        {
            StartTwoHandScale();
        }
    }

    void OnRelease(SelectExitEventArgs args)
    {
        if (grabInteractable.interactorsSelecting.Count < 2)
        {
            isTwoHandScaling = false;
            initialHandsDistance = 0f;
        }
    }

    void LateUpdate()
    {
        if (!isTwoHandScaling) return;

        float currentDistance = GetHandsDistance();
        if (currentDistance <= 0.001f) return;

        float scaleFactor = currentDistance / initialHandsDistance;
        Vector3 targetScale = initialScale * scaleFactor;
        targetScale = ClampScale(targetScale);

        transform.localScale = targetScale;
    }

    void StartTwoHandScale()
    {
        initialHandsDistance = GetHandsDistance();

        if (initialHandsDistance <= 0.001f) return;

        initialScale = transform.localScale;
        isTwoHandScaling = true;
    }

    float GetHandsDistance()
    {
        var hands = grabInteractable.interactorsSelecting;
        return Vector3.Distance(
            hands[0].transform.position,
            hands[1].transform.position
        );
    }

    Vector3 ClampScale(Vector3 scale)
    {
        float clamped = Mathf.Clamp(scale.x, minScale, maxScale);
        return Vector3.one * clamped;
    }
}

