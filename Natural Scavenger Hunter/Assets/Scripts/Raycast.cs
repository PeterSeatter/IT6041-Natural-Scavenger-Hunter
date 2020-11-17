using UnityEngine;

public class Raycast : MonoBehaviour
{
    private GameObject RaycastedObject;

    [SerializeField] private int RayLength = 10;
    [SerializeField] private LayerMask LayerMaskInteract;
    public int Wood;
    public int Bamboo;
    public Transform InteractionPrompt;


    private void Update()
    {
        Raycaster();
    }

    public void Raycaster()
    {
        RaycastHit Hit;
        Vector3 Forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, Forward, out Hit, RayLength, LayerMaskInteract.value))
        {
            if (RayLength >= 10 && Hit.collider.CompareTag("Wood"))
            {
                if (InteractionPrompt.gameObject.activeInHierarchy == false)
                {
                    InteractionPrompt.gameObject.SetActive(true);
                }
            }

            if (RayLength >= 10 && Hit.collider.CompareTag("Bamboo"))
            {
                if (InteractionPrompt.gameObject.activeInHierarchy == false)
                {
                    InteractionPrompt.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            //turn off panel
            InteractionPrompt.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown("f"))
        {
            Debug.Log("You've interacted with the object");
            //removes the object from the world
            //RaycastedObject.SetActive(false);

            if (Hit.collider.CompareTag("Wood"))
            {
                FindObjectOfType<Collected>().AddWood(Wood);
            }

            if (Hit.collider.CompareTag("Bamboo"))
            {
                FindObjectOfType<Collected>().AddBamboo(Bamboo);
            }
        }
    }
}