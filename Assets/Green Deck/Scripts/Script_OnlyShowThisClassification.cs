using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class OnlyShowThisClassification : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public PlaneClassification classification;

   public void OnEnable()
    {
        planeManager.planesChanged += SetupPlane;
    }

    public void OnDisable()
    {
        planeManager.planesChanged -= SetupPlane;
    }

    public void SetupPlane(ARPlaneChangedEventArgs obj)
    {
        ARPlane newPlane = obj.added;

        foreach (var plane in newPlane)
        {
            if(item.classification == classification)
            {
                //
            }
            else
            {
                Renderer itemRenderer = itemRenderer.GetComponent<Renderer>();
                Destroy(itemRenderer);
            }
        }
    }

   
}
