using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public CharacterController Controller;

    private Vector3 MoveDirection;
    public float GravityScale;

    public Transform Pivot;
    public float RotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //calls the Movement Method
        Movement();
    }

    public void Movement()
    {
        float yStore = MoveDirection.y;
        MoveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        MoveDirection = MoveDirection.normalized * MoveSpeed;
        MoveDirection.y = yStore;

        //moveDirection.y += Physics.gravity.y * GravityScale;
        MoveDirection.y -= GravityScale * Time.deltaTime;

        Controller.Move(MoveDirection * Time.deltaTime);

        //Move the player in different directions based on the camera look direction
        //if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        //{
        //    transform.rotation = Quaternion.Euler(0f, Pivot.rotation.eulerAngles.y, 0f);
        //    Quaternion NewRotation = Quaternion.LookRotation(new Vector3(MoveDirection.x, 0f, MoveDirection.z));
        //    transform.rotation = Quaternion.Slerp(transform.rotation, NewRotation, RotateSpeed * Time.deltaTime);
        //}

        if (Input.GetButtonDown("Jump"))
        {
            MoveDirection.y = JumpForce;

        }
    }
}
