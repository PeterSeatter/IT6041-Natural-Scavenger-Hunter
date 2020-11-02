using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    public float LastPositionY = 0f;
    public float FallDistance = 0f;
    public Transform Player;
    private CharacterController Controller;

    // Start is called before the first frame update
    void Start()
    {        
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        FallDamageAmount();
    }

    private void FallDamageAmount()
    {
        CurrentHealth = MaxHealth;

        if (LastPositionY > Player.transform.position.y)
        {
            FallDistance += LastPositionY - Player.transform.position.y;
        }

        LastPositionY = Player.transform.position.y;

        if (FallDistance >= 3 && Controller.isGrounded)
        {
            CurrentHealth -= Mathf.RoundToInt(FallDistance);
            FallReset();
            //Debug.Log("You've hit the ground");
        }

        if (FallDistance <= 3 && Controller.isGrounded)
        {
            FallReset();
        }
    }

    private void FallReset()
    {
        FallDistance = 0f;
        LastPositionY = 0f;
        //Debug.Log("It's reset for another drop");
    }
}
