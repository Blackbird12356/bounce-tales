using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;    
    [SerializeField] private float maxSpeed = 6f;   
    [SerializeField] private float airControl = 0.35f;  

    [Header("Jump")]
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float groundCheckRadius = 0.55f;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody rb;
    private Vector2 inputDir;
    private bool isGrounded;
    private bool jumpQueued;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

   
    private void Update()
    {
        inputDir.x = Input.GetAxisRaw("Horizontal");
        inputDir.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump")) jumpQueued = true;
    }


    private void FixedUpdate()
    {
        CheckGround();
        Move();
        if (jumpQueued && isGrounded) Jump();
        jumpQueued = false;
    }

    private void Move()
    {
        if (inputDir.sqrMagnitude < 0.01f) return;

        Vector3 fwd = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        fwd.y = right.y = 0f;

        Vector3 dir = (fwd * inputDir.y + right * inputDir.x).normalized;
        float control = isGrounded ? 1f : airControl;
        Vector3 targetVel = dir * moveSpeed * control;
        Vector3 horizVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        Vector3 delta = targetVel - horizVel;

        rb.AddForce(delta, ForceMode.VelocityChange);

        
        horizVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (horizVel.sqrMagnitude > maxSpeed * maxSpeed)
        {
            horizVel = horizVel.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(horizVel.x, rb.linearVelocity.y, horizVel.z);
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); 
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }

    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckRadius,  groundMask, QueryTriggerInteraction.Ignore);
    }
}
