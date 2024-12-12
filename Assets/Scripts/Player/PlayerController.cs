using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance;
        [Header("Movement Settings")] public float moveSpeed = 5f; // Speed of horizontal movement
        public float jumpForce = 10f; // Force applied for jumping
        public LayerMask groundLayer; // Layer considered as "ground" for jumping

        [Header("Ground Check")] public Transform groundCheck; // Point to check if the player is on the ground
        public float groundCheckRadius = 0.2f;

        public Rigidbody2D rb;
        public Animator animator;
        private bool isGrounded;
        private Vector2 moveInput;
        
        public bool isRunning;
        private bool isJumping;
        
        [Header("Character Settings")]
        public GameObject currentCharacter;
        public GameObject[] characters;

        private PlacePresent placePresentScript;
        private PickUpPresent pickUpPresentScript;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                Debug.Log("PlayerController Singleton Initialized");
            }
            else
            {
                Destroy(gameObject);
            }
            
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
            placePresentScript = gameObject.GetComponent<PlacePresent>();
            pickUpPresentScript = gameObject.GetComponent<PickUpPresent>();
        }

        private void Start()
        {
            if (GameManager.Instance != null)
            {
                transform.position = GameManager.Instance.playerPosition;
            }
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
            Debug.Log(isGrounded);
            if (value.isPressed && isGrounded) 
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
                isJumping = true;
            } else
            {
                isJumping = false;
            }
        }

        private void FixedUpdate()
        {
            // Horizontal movement
            if (rb != null)
            {
                rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
            }

            // Check if grounded
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            
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
        
        // public void OnCharacterSelect(InputValue value)
        // {
        //     int newIndex = Mathf.RoundToInt(value.Get<float>()) - 1; // Convert 1-based input to 0-based index
        //     SwitchCharacter(newIndex);
        // }
        
        public void SwitchCharacter(int index)
        {
            if (index < 0 || index >= characters.Length)
            {
                Debug.LogWarning("Invalid character index.");
                return;
            }
            
            if (currentCharacter != null)
            {
                Destroy(currentCharacter);
            }
            
            // GameObject targetPrefab = FindCharacterInScene(characters[index].name);
            // if (targetPrefab == null)
            // {
            //     Debug.LogWarning("Character not found in scene.");
            //     return;
            // }
            //
            // if (currentCharacter != null)
            // {
            //     currentCharacter.transform.SetParent(null);
            // }
            //
            // targetPrefab.transform.SetParent(transform);
            //
            // Vector3 tempPosition = currentCharacter != null ? currentCharacter.transform.position : transform.position;
            // if (currentCharacter != null)
            // {
            //     currentCharacter.transform.position = targetPrefab.transform.position;
            // }
            //
            // currentCharacter = targetPrefab;
            
            GameObject newCharacter = Instantiate(characters[index], transform.position, Quaternion.identity, transform);
            currentCharacter = newCharacter;
            
            currentCharacter.transform.localPosition = Vector3.zero;
            animator = currentCharacter.GetComponentInChildren<Animator>();
            
            currentCharacter.gameObject.name = characters[index].name;

            Debug.Log("Current Character name" + currentCharacter.gameObject.name);
            if (currentCharacter.gameObject.name == "Adult")
            {
                placePresentScript.isEnabled = true;
            }
            else
            {
                placePresentScript.isEnabled = false;
            }
            
            if (currentCharacter.gameObject.name == "Kid")
            {
                pickUpPresentScript.isEnabled = true;
            }
            else
            {
                pickUpPresentScript.isEnabled = false;
            }
            
            Debug.Log("Character switched to " + currentCharacter.name);
        }
        
        private GameObject FindCharacterInScene(string prefabName)
        {
            GameObject[] allCharacters = GameObject.FindGameObjectsWithTag("Player"); // Ensure all characters have the tag "Character"
            foreach (GameObject character in allCharacters)
            {
                if (character.name.StartsWith(prefabName))
                {
                    return character;
                }
            }

            return null; // Return null if no matching character is found
        }

    }
    


}