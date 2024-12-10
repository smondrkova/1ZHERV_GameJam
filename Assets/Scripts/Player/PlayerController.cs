using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")] public float moveSpeed = 5f; // Speed of horizontal movement
        public float jumpForce = 10f; // Force applied for jumping
        public LayerMask groundLayer; // Layer considered as "ground" for jumping

        [Header("Ground Check")] public Transform groundCheck; // Point to check if the player is on the ground
        public float groundCheckRadius = 0.2f;

        private Rigidbody2D rb;
        public Animator animator;
        private bool isGrounded;
        private Vector2 moveInput;
        
        private bool isRunning;
        private bool isJumping;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
        }

        public void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>(); // Read horizontal input
            
            if (moveInput.x > 0 || moveInput.x < 0)
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }
        }

        public void OnJump(InputValue value)
        {
            if (value.isPressed && isGrounded) 
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply jump force
                isJumping = true;
            } else
            {
                isJumping = false;
            }
        }

        private void FixedUpdate()
        {
            // Horizontal movement
            rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);

            // Check if grounded
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            
            Debug.Log(isGrounded);
            
            AnimatePlayer();
        }

        private void OnDrawGizmosSelected()
        {
            // Visualize the ground check in the scene view
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
        
        private void AnimatePlayer()
        {
            // rotate the Player correctly
            if (moveInput.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (moveInput.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (animator != null)
            {
                var speed =  Mathf.Abs(moveInput.x);
                var grounded = isGrounded;
                var run = isRunning;
                var jump = isJumping;
                
                animator.SetFloat("Speed", speed);
                animator.SetBool("Grounded", grounded);
                animator.SetBool("Run", run);
                
                if (jump)
                {
                    animator.SetTrigger("JumpTrigger");
                    isJumping = false;
                }
                
                
            }
        }
    }
}