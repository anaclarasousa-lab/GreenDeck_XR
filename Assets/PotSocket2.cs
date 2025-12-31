using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // Esto quita el error de SelectEnterEventArgs
using System.Collections.Generic;

public class PotSocket2 : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    public Transform spawnPoint;
    
    [Header("Configuración de Desbloqueo")]
    public List<PlantData> plantasRequeridas; // Arrastra aquí tus 4 SO de plantas base
    public GameObject cartaEspecial;          // La 5ta carta (desactívala en el Inspector)

    private GameObject currentPlant;

    // Se llama desde el evento Select Entered del Socket
    public void OnCardInserted(SelectEnterEventArgs args)
    {
        // 1. Buscamos el script en la carta. Usamos el nombre exacto de tu imagen: PlanDataPrefab
        PlanDataPrefab cardScript = args.interactableObject.transform.GetComponent<PlanDataPrefab>();

        // 2. IMPORTANTE: En tu imagen, la variable se llama plantData (con P minúscula)
        if (cardScript != null && cardScript.plantData != null)
        {
            Debug.Log("Socket detectó la planta: " + cardScript.plantData.name);
            
            if (currentPlant != null) Destroy(currentPlant);

            // Sumamos al contador del ScriptableObject
            cardScript.plantData.timesPlanted++; 

            // Instanciamos el modelo usando el prefab guardado en el SO
            currentPlant = Instantiate(cardScript.plantData.plantPrefab, spawnPoint.position, spawnPoint.rotation);
            
            CheckUnlockConditions();
        }
    }

    private void CheckUnlockConditions()
    {
        if (plantasRequeridas == null || plantasRequeridas.Count == 0) return;

        bool todasPlantadas = true;
        foreach (PlantData p in plantasRequeridas)
        {
            if (p.timesPlanted <= 0) 
            {
                todasPlantadas = false;
                break;
            }
        }

        if (todasPlantadas && cartaEspecial != null)
        {
            cartaEspecial.SetActive(true);
            Debug.Log("¡5ta carta desbloqueada!");
        }
    }

    public void OnCardRemoved(SelectExitEventArgs args)
    {
        if (currentPlant != null) Destroy(currentPlant);
    }
}