using UnityEngine;

public class BabyCowController : MonoBehaviour
{
    public string playerTag = "Player";
    public string mamaCowTag = "MamaCow";
    public float followDistance = 3f;
    public float stopDistance = 2f;
    public float moveSpeed = 5f;

    private Transform playerTransform;
    private Transform mamaCowTransform;
    private bool isFollowing = false;

    // Movement states
    private enum MovementState
    {
        Idle,
        MovingRight,
        MovingLeft,
        Pause
    }

    private MovementState currentMovementState = MovementState.Idle;
    private float moveDistance = 2f; // Distance to move before pausing
    private float pauseDuration = 2f; // Duration to pause after moving

    private float moveTimer = 0f; // Timer for current movement phase

    void Start()
    {
        // Find the player and mama cow GameObjects based on their tags
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        GameObject mamaCow = GameObject.FindGameObjectWithTag(mamaCowTag);

        if (player != null)
            playerTransform = player.transform;

        if (mamaCow != null)
            mamaCowTransform = mamaCow.transform;
    }

    void Update()
    {
        if (playerTransform == null || mamaCowTransform == null)
            return;

        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        // Check if the player is within follow distance
        if (distanceToPlayer <= followDistance)
        {
            isFollowing = true;

            // Move towards the player at the specified speed
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);

            // Check if near mama cow to stop following
            float distanceToMamaCow = Vector2.Distance(transform.position, mamaCowTransform.position);


            if (distanceToMamaCow <= stopDistance)
            {
                isFollowing = false;
                transform.position = Vector2.MoveTowards(transform.position, mamaCowTransform.position, moveSpeed * Time.deltaTime);
                // Optionally, perform any actions when near the mama cow (e.g., stop animations, trigger events)
            }
        }
        else
        {
            isFollowing = false;

            // Perform movement based on current state
            switch (currentMovementState)
            {
                case MovementState.Idle:
                    // Start moving right
                    currentMovementState = MovementState.MovingRight;
                    moveTimer = moveDistance / moveSpeed; // Calculate time to reach moveDistance
                    break;

                case MovementState.MovingRight:
                    // Move right
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                    moveTimer -= Time.deltaTime;

                    // Check if reached move distance
                    if (moveTimer <= 0f)
                    {
                        // Pause after moving right
                        currentMovementState = MovementState.Pause;
                        moveTimer = pauseDuration;
                    }
                    break;

                case MovementState.Pause:
                    // Pause before choosing direction
                    moveTimer -= Time.deltaTime;

                    // Check if pause duration is over
                    if (moveTimer <= 0f)
                    {
                        // Randomly choose to move left or right
                        if (Random.Range(0f, 1f) < 0.5f)
                        {
                            currentMovementState = MovementState.MovingLeft;
                        }
                        else
                        {
                            currentMovementState = MovementState.MovingRight;
                        }
                        // Reset moveTimer for new movement phase
                        moveTimer = moveDistance / moveSpeed;
                    }
                    break;

                case MovementState.MovingLeft:
                    // Move left
                    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                    moveTimer -= Time.deltaTime;

                    // Check if reached move distance
                    if (moveTimer <= 0f)
                    {
                        // Pause after moving left
                        currentMovementState = MovementState.Pause;
                        moveTimer = pauseDuration;
                    }
                    break;
            }
        }
    }
}
