using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "New Plant", menuName = "Garden/Plant Data")]
public class PlantData : ScriptableObject
{
    public string plantName;
    public GameObject cardPrefab;  // The Card visual
    public GameObject plantPrefab; // The actual Plant model

    [Header("Progreso")]
    public bool isUnlocked; 
    public int timesPlanted;
    public UnityAction OnDataChanged;
void Start()
    {
        timesPlanted = 0; 
    }
    public void RegisterPlanting()
    {
        timesPlanted ++;
        OnDataChanged?.Invoke();
    }
    public void SetUnlocked(bool state)
    {
        isUnlocked = state;
        OnDataChanged?.Invoke();
    }
}
