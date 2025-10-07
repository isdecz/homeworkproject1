using UnityEngine;


public class PlayerController : MonoBehaviour
    {
        public float moveSpeed;
        private Rigidbody2D myRigidBody;
        public float jumpSpeed;
        private Animator myAnim;
        public Transform groundCheck;
        public float groundCheckRadius; // Radius of groundcheck
        public LayerMask whatIsGround; // What layer can the player jump
        public bool isGrounded; //Is the player grounded
                                // Start is called before the first frame update
        void Start()
        {
            myRigidBody = GetComponent<Rigidbody2D>();
            myAnim = GetComponent<Animator>();
        }
        // Update is called once per frame
        void Update()
        {
            myAnim.SetFloat("Speed", Mathf.Abs(myRigidBody.linearVelocity.x));
            myAnim.SetBool("Grounded", isGrounded);
            // Player moving right
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                myRigidBody.linearVelocity = new Vector2(moveSpeed,
                myRigidBody.linearVelocity.y);
                transform.localScale = new Vector2(1f, 1f);
            }
            // Player moving left
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                myRigidBody.linearVelocity = new Vector2(-moveSpeed,
                myRigidBody.linearVelocity.y);
                transform.localScale = new Vector2(-1f, 1f);
            }
            // No slide
            else
            {
                myRigidBody.linearVelocity = new Vector2(0f,
                myRigidBody.linearVelocity.y);
            }
            //Jump
            isGrounded = Physics2D.OverlapCircle(groundCheck.position,
            groundCheckRadius, whatIsGround);
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                myRigidBody.linearVelocity = new Vector2(myRigidBody.linearVelocity.x,
                jumpSpeed);
            }
        }
    }


