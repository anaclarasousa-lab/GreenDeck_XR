using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Notification : MonoBehaviour
{
    public GameObject notificationPanel;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake() 
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        interactable.selectEntered.AddListener(ShowNotification);    
    }

private void ShowNotification(SelectEnterEventArgs args)
    {
        if (notificationPanel != null)
            notificationPanel.SetActive(true);
    }
   
   public void CloseNotification()
   {
    if(notificationPanel != null)
        notificationPanel.SetActive(false);
   }
}