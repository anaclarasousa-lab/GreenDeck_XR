using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PotSocket : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket; // El socket de la maceta
    public Transform spawnPoint;      // Donde aparecer� la planta

    // Prefabs de plantas
    public GameObject photosPrefab;
    public GameObject monsteraPrefab;
    public GameObject violetaPrefab;
    public GameObject tulipanPrefab;
    public GameObject amarilisPrefab;

    public GameObject currentPlant;

    void OnEnable()
    {
        socket.selectEntered.AddListener(OnCardInserted);
    }

    void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnCardInserted);
    }

    public void OnCardInserted(SelectEnterEventArgs args)
    {
        GameObject cardObject = args.interactableObject.transform.gameObject;
        string cardTag = cardObject.tag;

        // Elimina planta anterior si existe
        if (currentPlant != null)
            Destroy(currentPlant);

        // Instancia la planta correspondiente seg�n el tag
        switch (cardTag)
        {
            case "Photos":
                currentPlant = Instantiate(photosPrefab, spawnPoint.position, spawnPoint.rotation);
                break;
            case "Monstera":
                currentPlant = Instantiate(monsteraPrefab, spawnPoint.position, spawnPoint.rotation);
                break;
            case "Violeta":
                currentPlant = Instantiate(violetaPrefab, spawnPoint.position, spawnPoint.rotation);
                break;
            case "Tulipan":
                currentPlant = Instantiate(tulipanPrefab, spawnPoint.position, spawnPoint.rotation);
                break;
            case "Amarilis":
                currentPlant = Instantiate(amarilisPrefab, spawnPoint.position, spawnPoint.rotation);
                break;
            default:
                Debug.LogWarning("Carta con tag desconocido: " + cardTag);
                break;
        }

    }
}

