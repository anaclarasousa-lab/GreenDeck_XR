using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.VisualBasic;

public class spawner : MonoBehaviour
{
    [Header("Plantas")]

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
    
    [Header("Notificaciones")]

    public GameObject tooltipObject;

    [Header("Sonido")]
    public AudioClip spawnClip;
    public AudioClip unlockedClip;




    public void SpawnPhotos()
    {
        if(Photos != null && PhotosPosition != null)
        {
            UnityEngine.Vector3  spawnPhotosPos = PhotosPosition.position;
            UnityEngine.Quaternion spawnPhotosRot = UnityEngine.Quaternion.Euler(0, -90, 0);
            Instantiate(Photos, spawnPhotosPos, spawnPhotosRot);

            AudioSource.PlayClipAtPoint (spawnClip, transform.position);

        }

    }
    public void SpawnMonstera()
    {
         if(Monstera != null && MonsteraPosition != null)
        {
            UnityEngine.Vector3  spawnMonsteraPos = MonsteraPosition.position;
            UnityEngine.Quaternion spawnMonsteraRot = UnityEngine.Quaternion.Euler(0, -90, 0);
            Instantiate(Monstera, spawnMonsteraPos, spawnMonsteraRot);

            AudioSource.PlayClipAtPoint (spawnClip, transform.position);

        }
    }
    public void SpawnVioleta()
    {
        if(Violeta != null && VioletaPosition != null)
        {
            UnityEngine.Vector3  spawnVioletaPos = VioletaPosition.position;
            UnityEngine.Quaternion spawnVioletaRot = UnityEngine.Quaternion.Euler(0, -90, 0);
            Instantiate(Violeta, spawnVioletaPos,spawnVioletaRot);

            AudioSource.PlayClipAtPoint (spawnClip, transform.position);

        }
    }
    public void SpawnTulipan()
    {
        if(Tulipan != null && TulipanPosition != null)
        {
            UnityEngine.Vector3  spawnTulipanPos = TulipanPosition.position;
            UnityEngine.Quaternion spawnTulipanRot = UnityEngine.Quaternion.Euler(0, -90, 0);
            Instantiate(Tulipan, spawnTulipanPos,spawnTulipanRot);

            AudioSource.PlayClipAtPoint (spawnClip, transform.position);

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

                AudioSource.PlayClipAtPoint (spawnClip, transform.position);


                }
        }
        else
        {
            tooltipObject.SetActive(true);
            
        }
    }

}
