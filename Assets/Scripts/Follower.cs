using UnityEngine;

public class Follower : MonoBehaviour
{
    public static Follower Instance;
    
    [Header("Follow Settings")]
    public Player.PlayerController player;
    private Transform target; 
    public float followSpeed = 5f; 
    public float followDistance = 1.5f; 

    private Animator animator;
    private Vector3 lastPosition;
    
    public bool isToRightOfTarget;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
        target = player.transform;
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        if (target == null) return;
        
        isToRightOfTarget = transform.position.x > target.position.x;
        
        float distance = Vector3.Distance(transform.position, target.position);
        
        if (distance > followDistance)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * followSpeed * Time.deltaTime;
    
            AnimateFollower();
        }
        
        lastPosition = transform.position;
    }
    
    private void AnimateFollower()
    {
        if (animator == null) return;

        if (player.isRunning)
        {
            animator.SetBool("Run", true);
        } 
        else
        {
            animator.SetBool("Run", false);
        }
        
        // rotate the character's direction to face the target
        Vector3 direction = target.position - transform.position;
        if (direction.x > 0) transform.localScale = new Vector3(1, 1, 1); 
        else if (direction.x < 0) transform.localScale = new Vector3(-1, 1, 1); 
    }


}