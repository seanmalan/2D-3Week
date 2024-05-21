using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCowMovement : MonoBehaviour
{

    public float followDistance = 2f;
    public float stopDistance = 1f;
    public float moveSpeed = 5f;


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
       
    }

    void Update()
    {
       

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

