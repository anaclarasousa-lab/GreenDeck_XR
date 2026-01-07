using UnityEngine;
using System.Collections; 
using System.Collections.Generic; 
public class progressionManager : MonoBehaviour
{
    public List <PlantData> allPlants;
   
    [Header("Sounds")]
    public AudioClip unlocking; 
    public AudioClip locking;  
    
    public PlantData amarilisData;
   
   private void OnEnable()
{
    // Escuchamos a todas las plantas de la lista
    foreach(var plant in allPlants)
    {
        if(plant != null) plant.OnDataChanged += CheckAmarilisRequirements;
    }
}

private void CheckAmarilisRequirements()
{
    // Si ya está desbloqueada, no hacemos nada
    if (amarilisData.isUnlocked) return;

    // Llamamos a tu lógica de validación
    if (CanUnlock(amarilisData))
    {
        amarilisData.SetUnlocked(true);
        Debug.Log("¡Amarilis desbloqueada automáticamente por el Manager!");
    }
}

    private bool CanUnlock(PlantData target)
    {
        if(target.plantName == "Amarilis")
        {
             foreach (var p in allPlants)
            {
                if (p == target ) continue;
                if(p.timesPlanted <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        return false;
       
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
