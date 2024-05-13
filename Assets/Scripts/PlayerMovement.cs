using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private float speed = 5f;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if(movement.x != 0 || movement.y != 0)
        {
           
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

            animator.SetBool("IsWalking", true);
        } else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
       rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        
    }

}
