using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnCarta : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnSpeed = 2;
    public InputActionProperty inputAction;

    //Update is called once per  frame
    void Update()
    {
        if(inputAction.action.WasPressedThisFrame())
        {
            GameObject spawnedCube = Instantiate(cubePrefab, transform.position, transform.rotation);
            Rigidbody cubeRigibody = spawnedCube.GetComponent<Rigidbody>();
            cubeRigibody.linearVelocity = transform.forward * spawnSpeed;
        }
    }
}
