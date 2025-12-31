using UnityEngine;
using UnityEngine.EventSystems; // Necesario para detectar el puntero de UI

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string content = "Bloqueado: Planta las 4 especies básicas primero.";
    public Vector3 offset = new Vector3(0, 0, 0); // Ajuste de posición en el Canvas

    // Se activa cuando el rayo XR entra en el botón
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Usamos la posición del ratón o del puntero XR
        HoverManager.OnMouseHover?.Invoke(content, transform.position + offset);
    }

    // Se activa cuando el rayo XR sale del botón
    public void OnPointerExit(PointerEventData eventData)
    {
        HoverManager.OnMouseLoseFocus?.Invoke();
    }
}