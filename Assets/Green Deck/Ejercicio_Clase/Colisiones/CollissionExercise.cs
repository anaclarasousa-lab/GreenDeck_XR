using UnityEngine;

public class CollissionExercise : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Blue")
            {
            collision.gameObject.SetActive(false); 
        }
    }
}
