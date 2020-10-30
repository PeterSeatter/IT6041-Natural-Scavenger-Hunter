using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private static HealthManager _instance;
    public static HealthManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public int MaxHealth;
    public int CurrentHealth;
    public float LastPositionY = 0f;
    public float FallDistance = 0f;
    public Transform Player;
    private CharacterController Controller;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        FallDamageAmount();
    }

    private void FallDamageAmount()
    {
        if (LastPositionY > Player.transform.position.y)
        {
            FallDistance += LastPositionY - Player.transform.position.y;
        }

        LastPositionY = Player.transform.position.y;

        if (FallDistance >= 5 && Controller.isGrounded)
        {
            CurrentHealth -= Mathf.RoundToInt(FallDistance);
            FallReset();
            //Debug.Log("You've hit the ground");
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
