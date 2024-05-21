using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{

    public Sprite Broken;
    public Sprite Fixed;
    public KeyCode interactKey = KeyCode.E; // Key to press for interaction
    public LayerMask interactableLayer; // Layer containing interactable objects (e.g., fences)

    public GameObject fixedFencePrefab; // Prefab for the fixed fence

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        // Raycast to detect interactable objects
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, transform.right, 1f, interactableLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.right, 1f, interactableLayer);

        if (hitLeft.collider != null && hitLeft.collider.CompareTag("brokenFenceLeft"))
        {
            
            GetComponent<SpriteRenderer>().sprite = Fixed;
        }

        if (hitRight.collider != null && hitRight.collider.CompareTag("brokenFenceRight"))
        {
            GetComponent<SpriteRenderer>().sprite = Fixed;
        }
    }
}