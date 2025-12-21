using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    public GameObject cardMenu; // Arrastra aquí tu CardMenuCanvas

    public void ToggleCardMenu()
    {
        if (cardMenu != null)
        {
            // Invierte el estado: si está activo lo apaga, si está apagado lo enciende
            bool newState = !cardMenu.activeSelf;
            cardMenu.SetActive(newState);
            
            // Si lo estamos encendiendo, el Lazy Follow hará el Snap automático
            Debug.Log("Estado del menú de cartas: " + newState);
        }
    }
}