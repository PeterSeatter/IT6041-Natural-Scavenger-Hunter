using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Transform SpawnPoint;
    public Rigidbody Prefab;
    //private readonly Collected wood;
    public int AmountOfWood = 1;

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
        FindObjectOfType<Collected>().AddWood(AmountOfWood);
        AmountOfWood = prAddCount;
        Rigidbody RigidPrefab;
        Debug.Log("Triggered");
        Debug.Log("Amount of: " + AmountOfWood);
        if (AmountOfWood.Equals(5))
        {
            Debug.Log("Spawned item");
            RigidPrefab = Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
        }
    }
}
