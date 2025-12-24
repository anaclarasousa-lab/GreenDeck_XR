using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketLayerSwitcher : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    
    [Header("Configuraci�n de Capas")]
    public string originalLayerName = "Default";
    public string socketLayerName = "Maceta"; // La capa que no colisiona con la carta

    private int originalLayer;
    private int socketLayer;

    void Awake()
    {
        socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
        originalLayer = LayerMask.NameToLayer(originalLayerName);
        socketLayer = LayerMask.NameToLayer(socketLayerName);
    }

    void OnEnable()
    {
        socket.selectEntered.AddListener(SwitchToSocketLayer);
        socket.selectExited.AddListener(SwitchToOriginalLayer);
    }

    void OnDisable()
    {
        socket.selectEntered.RemoveListener(SwitchToSocketLayer);
        socket.selectExited.RemoveListener(SwitchToOriginalLayer);
    }

    private void SwitchToSocketLayer(SelectEnterEventArgs args)
    {
        // Cambiamos la maceta (este objeto o su padre) al layer especial
        // Si el script est� en un hijo de la maceta, usa transform.root o transform.parent
        gameObject.layer = socketLayer;
        Debug.Log("Carta en socket: Maceta cambiada a layer " + socketLayerName);
    }

    private void SwitchToOriginalLayer(SelectExitEventArgs args)
    {
        // Devolvemos la maceta al layer original para que todo sea normal
        gameObject.layer = originalLayer;
        Debug.Log("Carta fuera: Maceta devuelta a layer " + originalLayerName);
    }
}
