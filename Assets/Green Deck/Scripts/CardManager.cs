using UnityEngine; // This line fixes the "MonoBehaviour" and "Transform" errors

public class CardManager : MonoBehaviour
{
    public Transform spawnPoint; 

    public void SpawnCard(PlantData selectedPlant)
    {
        // Safety check to make sure you assigned the data in the Inspector
        if (selectedPlant == null) 
        {
            Debug.LogError("No PlantData assigned to the button!");
            return;
        }

        // Instantiate the card prefab defined in the ScriptableObject
        GameObject newCard = Instantiate(selectedPlant.cardPrefab, spawnPoint.position, spawnPoint.rotation);
        
        // Pass the data to the card so it knows what it is
        newCard.GetComponent<CardController>().data = selectedPlant;
    }
}