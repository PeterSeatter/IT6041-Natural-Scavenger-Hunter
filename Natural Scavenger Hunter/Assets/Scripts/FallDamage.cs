using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public float LastPositionY = 0f;
    public float FallDistance = 0f;
    public Transform Player;
    private CharacterController Controller;
    private HealthManager HM;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
        //HealthManager HM = gameObject.GetComponent("HealthManager") as HealthManager;
        HealthManager HM = gameObject.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FallDamageAmount();        
    }

    public void FallDamageAmount()
    {    
        if (LastPositionY > Player.transform.position.y)
        {
            FallDistance += LastPositionY - Player.transform.position.y;
        }

        LastPositionY = Player.transform.position.y;

        if (FallDistance >= 5 && Controller.isGrounded)
        {
            HM.CurrentHealth -= Mathf.RoundToInt(FallDistance);
            FallReset();
            Debug.Log("You've hit the ground");
        }

        if (FallDistance <= 5 && Controller.isGrounded)
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
