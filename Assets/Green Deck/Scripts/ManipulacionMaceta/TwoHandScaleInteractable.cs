using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class TwoHandScaleInteractable : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    public float scaleSpeed = 1.0f;
    public float minScale = 0.3f;
    public float maxScale = 2.0f;

    private Vector3 initialScale;
    private float initialHandsDistance;

    void Awake()
    {
        initialScale = transform.localScale;

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
            initialHandsDistance = GetHandsDistance();
            initialScale = transform.localScale;
        }
    }

    void OnRelease(SelectExitEventArgs args)
    {
        if (grabInteractable.interactorsSelecting.Count < 2)
        {
            initialHandsDistance = 0f;
        }
    }

    void Update()
    {
        if (grabInteractable.interactorsSelecting.Count == 2)
        {
            float currentDistance = GetHandsDistance();
            float scaleFactor = currentDistance / initialHandsDistance;

            Vector3 targetScale = initialScale * scaleFactor;
            targetScale = ClampScale(targetScale);

            transform.localScale = targetScale;
        }
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
