using UnityEngine;
[CreateAssetMenu(fileName = "New Plant", menuName = "Garden/Plant Data")]
public class PlantData : ScriptableObject
{
    public string plantName;
    public GameObject cardPrefab;  // The Card visual
    public GameObject plantPrefab; // The actual Plant model

    [Header("Progreso")]
    public bool isUnlocked; 
    public int timesPlanted;
}
