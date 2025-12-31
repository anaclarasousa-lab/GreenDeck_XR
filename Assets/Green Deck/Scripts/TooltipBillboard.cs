using UnityEngine;

public class TooltipBillboard : MonoBehaviour
{
    // Usamos LateUpdate para que la rotación se calcule después de que la cámara se mueva
    void LateUpdate()
    {
        if (Camera.main != null)
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, 
                             Camera.main.transform.rotation * Vector3.up);
        }
    }
}