using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DelayedObjectActivator : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("Tiempo en segundos antes de activar los objetos")]
    public float delayInSeconds = 5f;

    [Tooltip("Arrastra aquí todas las macetas y cartas que deben empezar desactivadas")]
    public List<GameObject> objectsToActivate;

    void Awake()
    {
        // Por seguridad, nos aseguramos de que empiecen desactivados
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null) obj.SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(ActivateRoutine());
    }

    IEnumerator ActivateRoutine()
    {
        // Esperamos el tiempo configurado
        yield return new WaitForSeconds(delayInSeconds);

        // Activamos cada objeto de la lista
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

        Debug.Log("¡Objetos activados! El Passthrough ya debería tener planos listos.");
    }
}