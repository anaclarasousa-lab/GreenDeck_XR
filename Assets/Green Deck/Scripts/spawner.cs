using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class spawner : MonoBehaviour
{
    public GameObject Photos;
    public Transform PhotosPosition;
    public GameObject Monstera;
    public Transform MonsteraPosition;

    public GameObject Violeta;
    public Transform VioletaPosition;

    public GameObject Tulipan;
    public Transform TulipanPosition;

    public GameObject Amarilis;
    public Transform AmarilisPosition;
    public PlantData amarilisData; 
    public GameObject tooltipObject;





    public void SpawnPhotos()
    {
        if(Photos != null && PhotosPosition != null)
        {
            UnityEngine.Vector3  spawnPhotosPos = PhotosPosition.position;
            UnityEngine.Quaternion spawnPhotosRot = UnityEngine.Quaternion.Euler(0, -90, 0);
            Instantiate(Photos, spawnPhotosPos, spawnPhotosRot);

        }

    }
    public void SpawnMonstera()
    {
         if(Monstera != null && MonsteraPosition != null)
        {
            Instantiate(Monstera, MonsteraPosition.position, MonsteraPosition.rotation);

        }
    }
    public void SpawnVioleta()
    {
        if(Violeta != null && VioletaPosition != null)
        {
            Instantiate(Violeta, VioletaPosition.position, VioletaPosition.rotation);

        }
    }
    public void SpawnTulipan()
    {
        if(Tulipan != null && TulipanPosition != null)
        {
            Instantiate(Tulipan, TulipanPosition.position, TulipanPosition.rotation);

        }    
    }
    public void SpawnAmarilis()
    {        
        if(amarilisData != null && amarilisData.isUnlocked)
        {
            if(Amarilis != null && AmarilisPosition != null)
                {
                UnityEngine.Vector3  spawnAmarilisPos = AmarilisPosition.position;
                UnityEngine.Quaternion spawnAmarilisRot = UnityEngine.Quaternion.Euler(0, -90, 0);
                Instantiate(Amarilis, spawnAmarilisPos, spawnAmarilisRot);


                }
        }
        else
        {
            tooltipObject.SetActive(true);
            
        }
    }

}
