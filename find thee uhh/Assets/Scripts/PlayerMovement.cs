using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;
    public float jumpCoolDown;
    public float airMulti;
    bool readyToJump;



    [Header("KeyBindings")]
    public KeyCode jumpKey = KeyCode.Space;


    [Header("Ground Sheek ya know :P")]
    public float playerHeight;
    public LayerMask whatIsGroud;
    [SerializeField]
    bool grounded;
    public float groundDrag;

    [Header("Refrences")]
    public Transform orientation;
    public GameObject Camera;
    public GameObject Gun;




    public Vector3 moveDierction;

    public Rigidbody rb;

    public float horizontalInput;
    public float verticalInput;

    void Start()
    {
        readyToJump = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Gun.GetComponent<Collider>();




    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGroud);

        MyInput();


        if (grounded)
        {
            rb.drag = groundDrag;
        }

        else
        {
            rb.drag = 0;
        }

        SpeedControl();

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // jump 

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();

            Invoke(nameof(ResetJump), jumpCoolDown);
        }

    }


    private void MovePlayer()
    {
        moveDierction = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDierction.normalized * moveSpeed * 10f, ForceMode.Force);


        //on da ground rose??

        if (grounded)
        {
            rb.AddForce(moveDierction.normalized * moveSpeed * 10f, ForceMode.Force);
        }


        //FLLLY MF FLLLY (in air)

        else if (!grounded)
        {
            rb.AddForce(moveDierction.normalized * moveSpeed * 10f * airMulti, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);


        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }

    private void ResetJump()
    {
        readyToJump = true;
    }

}
