using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float wallRunSpeed;

    //jump
    public float jumpForce;
    public float jumpCoolDown;
    public float airMulti;
    bool readyToJump;



    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;



    [Header("KeyBindings")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;


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
    public MovementState state;




    [Header("Slope Handling")]
    public float maxSlopeANGL;
    private RaycastHit slopeHit;
    private bool exitingSlope;





    public enum MovementState
    {
        walking,
        crouching,
        sprinting,
        wallRunning,
        air,
    }

    public bool wallRunning;



    void Start()
    {
        readyToJump = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Gun.GetComponent<Collider>();

        startYScale = transform.localScale.y;




    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGroud);

        MyInput();
        SpeedControl();
        StateHandler();


        if (grounded)
        {
            rb.drag = groundDrag;
        }

        else
        {
            rb.drag = 0;
        }



    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // beginning of all methods


    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump 

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();

            Invoke(nameof(ResetJump), jumpCoolDown);
        }



        // crouching input checker

        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

        }

        // stop crouch
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }


    }


    private void MovePlayer()
    {

        //movement direction

        moveDierction = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //rb.AddForce(moveDierction.normalized * moveSpeed * 10f, ForceMode.Force);


        //on slopeee salope
        if (onSlope())
        {
            rb.AddForce(GetSlopeMoveDirection(moveDierction) * moveSpeed * 20f, ForceMode.Force);
        }
        //on da ground rose??

        else if (grounded)
        {
            rb.AddForce(moveDierction.normalized * moveSpeed * 10f, ForceMode.Force);
        }


        //FLLLY MF FLLLY (in air)

        else if (!grounded)
        {
            rb.AddForce(moveDierction.normalized * moveSpeed * 10f * airMulti, ForceMode.Force);
        }


        rb.useGravity = !onSlope();




    }

    private void SpeedControl()
    {

        //limiting speed on slope
        if (onSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed;
            }
        }

        else
        {

            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);


            //limiting speed (velocity)
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }

    }

    private void Jump()
    {
        exitingSlope = true;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }

    private void ResetJump()
    {
        readyToJump = true;
        exitingSlope = false;
    }



    public void StateHandler()
    {

        //wall running here!!

        if (wallRunning)
        {
            state = MovementState.wallRunning;
            moveSpeed = wallRunSpeed;
        }





        // Crouching here!
        if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;

        }

        //sprinitng here!

        else if (grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;

        }

        //walking here!
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        // MF IS FLYIN DA HEEEEL (in air here!)
        else
        {
            state = MovementState.air;

        }
    }



    public bool onSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit,playerHeight * 0.5f + 0.3f))
        {
            
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeANGL && angle != 0;
        }
        return false;
    }

    public Vector3 GetSlopeMoveDirection(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal).normalized;
    }






}