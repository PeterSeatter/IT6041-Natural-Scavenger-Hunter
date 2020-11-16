using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private GameObject RaycastedObject;

    [SerializeField] private int RayLength = 10;
    [SerializeField] private LayerMask LayerMaskInteract;
    public int Wood;
    public int Bamboo;
    //public TextMeshProUGUI InteractionText;

    private void Update()
    {
        Raycasting();
    }

    public void Raycasting()
    {
        RaycastHit Hit;
        Vector3 Forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, Forward, out Hit, RayLength, LayerMaskInteract.value))
        {
            if (Hit.collider.CompareTag("Object"))
            {
                //GameObject.Find("Panel");
                
                if (GameObject.Find("Panel"))
                {
                    RaycastedObject.SetActive(true);
                    Debug.Log("Panel Active");
                }

                //InteractionText.SetText("Press F to Interact");
                RaycastedObject = Hit.collider.gameObject;

                if (Input.GetKeyDown("f"))
                {
                    Debug.Log("You've interacted with the object");
                    //removes the object from the world
                    //RaycastedObject.SetActive(false);
                    if (GameObject.FindWithTag("Wood"))
                    {
                        FindObjectOfType<Collected>().AddWood(Wood);
                    }

                    if (GameObject.FindWithTag("Bamboo"))
                    {
                        FindObjectOfType<Collected>().AddBamboo(Bamboo);
                    }
                }
            }
        }
    }
    //public void InteractText()
    //{
    //    InteractionText.SetText("Press F to Interact");
    //}
}
