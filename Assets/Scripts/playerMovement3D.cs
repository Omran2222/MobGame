using UnityEngine;

public class playerMovement3D : MonoBehaviour
{
    //[SerializeField] private SoundManager sm;
    private Rigidbody rb;
    //camera stuff
    [SerializeField] private float playerSpeed=6f;
    [SerializeField] private CharacterController controller;
     private float turnSmoothTime = 0.1f;
    [SerializeField] Transform cam;
    private float turnSmoothVelocity;
    //gravity _________________________________________________________________
    private float gravity = -19.62f;
    private Vector3 velocity;
    [SerializeField]private LayerMask ground;
    [SerializeField]private Transform groundCheck;
    private float groundDistance = 0.4f;
    public bool isGrounded;
    //jump
    [SerializeField] private float jumpHight;

   

    void Update()
    {
       
        //normal gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);
        if (isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        // ________________________________________________
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xMovement, 0, zMovement).normalized;
        if (movement.magnitude >= 0.1f)
        {
            //calculate the angle +cam angle
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg +cam.eulerAngles.y;
            //smooth the rotation
           // float angleS = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //apply the rotation
           // transform.rotation = Quaternion.Euler(0f,angleS,0f);
            //rotation too dir
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * playerSpeed * Time.deltaTime);
            
        }
          // check if player in the ground / preform jump
        if (Input.GetButtonDown(("Jump")) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -2f * gravity);
            
           // sm.PlayJumpSound();
        }


        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    

   

   
}
