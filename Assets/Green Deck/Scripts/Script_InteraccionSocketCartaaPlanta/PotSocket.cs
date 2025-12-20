using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PotSocket : MonoBehaviour
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
        currentCard = args.interactableObject.transform.gameObject;
        string cardTag = currentCard.tag;

        // Elimina planta anterior
        if (currentPlant != null)
            Destroy(currentPlant);

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

        // Avisar a la carta de que salió del socket
        DestroyCardAfterSocket destroyScript =
            args.interactableObject.transform.GetComponent<DestroyCardAfterSocket>();

        if (destroyScript != null)
        {
            destroyScript.MarkRemovedFromSocket();
        }
    }
}