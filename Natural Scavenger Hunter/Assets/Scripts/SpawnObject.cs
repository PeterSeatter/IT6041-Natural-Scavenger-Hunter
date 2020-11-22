using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Transform SpawnPoint;
    public Rigidbody Prefab;
    //private readonly Collected wood;
    public int AmountOfWood;
    public int AmountOfBamboo;
    public int AmountRequired = 5;

    private void Start()
    {
        //_ = GetComponent<Collected>().CurrentWood;
        //int AmountOfWood = wood.CurrentWood;
    }

    private void OnTriggerEnter(Collider other)
    {                
        AddCount(AmountOfWood);   
    }

    public void AddCount(int prAddCount)
    {
        AmountOfWood = Collected.CurrentWood;
        AmountOfBamboo = Collected.CurrentBamboo;
        //FindObjectOfType<Collected>().AddWood(AmountOfWood);
        //AmountOfWood += prAddCount;
        Rigidbody RigidPrefab;
        Debug.Log("Triggered");
        Debug.Log("Amount of: " + AmountOfWood);
        if (AmountOfWood.Equals(AmountRequired))
        {
            Debug.Log("Spawned item");
            RigidPrefab = Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
            if (Collected.CurrentWood <= 5)
            {
                Collected.CurrentWood =- AmountRequired;
            }
        }

        if (AmountOfBamboo.Equals(AmountRequired))
        {
            Debug.Log("Spawned item");
            RigidPrefab = Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
            AmountOfBamboo =- AmountRequired;
        }

        if (AmountOfBamboo.Equals(5) && AmountOfWood.Equals(5))
        {
            Debug.Log("Spawned item");
            RigidPrefab = Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
            AmountOfBamboo =- AmountRequired;
            Collected.CurrentWood = -AmountRequired;
        }
    }
}
