using UnityEngine;
using System.Collections; 
using System.Collections.Generic; 
public class progressionManager : MonoBehaviour
{
    public List <PlantData> allPlants;

    [Header("Sounds")]
    public AudioClip unlocking; 
    public AudioClip locking;  
    
   
    public void CheckUnlocks()
    {
        foreach(var plant in allPlants)
        {
            if(!plant.isUnlocked)
            {
                if(CanUnlock(plant))
                {
                    plant.isUnlocked = true; 
                }
            }
        }
    }

    private bool CanUnlock(PlantData target)
    {
        if(target.plantName == "Amarilis")
        {
             foreach (var p in allPlants)
            {
                if (p == target ) continue;
                if(p.isUnlocked && p.timesPlanted <= 0)
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
