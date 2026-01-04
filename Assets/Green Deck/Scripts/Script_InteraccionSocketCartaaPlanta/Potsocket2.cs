using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Potsocket2 : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    public Transform spawnPoint;

    public GameObject photosPrefab;
    public GameObject monsteraPrefab;
    public GameObject violetaPrefab;
    public GameObject tulipanPrefab;
    public GameObject amarilisPrefab;

    private GameObject currentPlant;
    private GameObject currentCard;

    void OnEnable()
    {
        socket.selectEntered.AddListener(OnCardInserted);
        socket.selectExited.AddListener(OnCardRemoved);
    }

    void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnCardInserted);
        socket.selectExited.RemoveListener(OnCardRemoved);
    }

  private void OnCardInserted(SelectEnterEventArgs args)
{
    // 1. Identificamos el objeto que entró (la carta)
    GameObject cardObject = args.interactableObject.transform.gameObject;

    // 2. Buscamos el script "puente" que creamos (PlantSeed)
    if (cardObject.TryGetComponent<PlantSeed>(out PlantSeed seed))
    {
        // 3. Eliminamos la planta anterior si existe
        if (currentPlant != null) 
        {
            Destroy(currentPlant);
        }

        // 4. INSTANCIACIÓN: Usamos el prefab que guardaste en el ScriptableObject
        // Accedemos a seed -> data (PlantData) -> plantPrefab
        currentPlant = Instantiate(seed.data.plantPrefab, spawnPoint.position, spawnPoint.rotation);

        // 5. REGISTRO: Sumamos +1 al contador de esa planta específica
        seed.data.RegisterPlanting();

        Debug.Log("Se ha plantado: " + seed.data.plantName + ". Total: " + seed.data.timesPlanted);
    }
    else
    {
        Debug.LogWarning("La carta insertada no tiene el script PlantSeed asignado.");
    }
}
    private void OnCardRemoved(SelectExitEventArgs args)
    {
        // Quitar la planta
        if (currentPlant != null)
        {
            Destroy(currentPlant);
            currentPlant = null;
        }

        // Avisar a la carta de que sali� del socket
        DestroyCardAfterSocket destroyScript =
            args.interactableObject.transform.GetComponent<DestroyCardAfterSocket>();

        if (destroyScript != null)
        {
            destroyScript.MarkRemovedFromSocket();
        }
    }
}