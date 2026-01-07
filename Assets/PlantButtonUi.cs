using UnityEngine;
using System.Numerics;
using UnityEngine.UI; 

public class PlantButtonUi : MonoBehaviour
{
    public PlantData plantData; 
    public Button myButton; 

    public Image displayImage;
    public Sprite lockedVisual; 
    public Sprite unlockedVisual;

    public GameObject toolTip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }
    
    public void RefreshUI()
    {
        if (plantData == null || displayImage == null || myButton == null) return;

        myButton.interactable = plantData.isUnlocked; 

        if(plantData.isUnlocked)
        {
            displayImage.sprite = unlockedVisual;
        }
        else
        {
            displayImage.sprite = lockedVisual;

        }
    }
    // Update is called once per frame
    void Update()
    {
        RefreshUI();

    }

}
