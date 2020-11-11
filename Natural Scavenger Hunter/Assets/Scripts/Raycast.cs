using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private GameObject RaycastedObject;

    [SerializeField] private int RayLength = 10;
    [SerializeField] private LayerMask LayerMaskInteract;

    private void Update()
    {
        RaycastHit Hit;
        Vector3 Forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, Forward, out Hit, RayLength, LayerMaskInteract.value))
        {
            if (Hit.collider.CompareTag("Object"))
            {
                RaycastedObject = Hit.collider.gameObject;

                if (Input.GetKeyDown("f"))
                {
                    Debug.Log("You've interacted with the object");
                    //removes the object from the world
                    //RaycastedObject.SetActive(false);
                }
            }
        }
    }
}
