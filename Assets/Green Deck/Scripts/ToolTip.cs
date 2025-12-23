using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class toolTip : MonoBehaviour
{
    public GameObject tooltipObject; 
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake() {
        
    interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();

    interactable.hoverEntered.AddListener(ShowTooltip);
    interactable.hoverExited.AddListener(HideTooltip);
    
        
    }

    private void ShowTooltip(HoverEnterEventArgs args) => tooltipObject.SetActive(true);
    private void HideTooltip(HoverExitEventArgs args) => tooltipObject.SetActive(false);

}
