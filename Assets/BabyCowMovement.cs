using UnityEngine;

public class BabyCowController : MonoBehaviour
{
    public string playerTag = "Player";
    public string mamaCowTag = "Mama Cow";
    public float followDistance = 2f;
    public float stopDistance = 1f;
    public float moveSpeed = 5f;

    private Transform playerTransform;
    private Transform mamaCowTransform;
    private bool isFollowing = false;

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
        Debug.Log("Distance to Player: " + distanceToPlayer);

        // Check if the player is within follow distance
        if (distanceToPlayer <= followDistance)
        {
            isFollowing = true;
            Debug.Log("Following Player");

            // Move towards the player at the specified speed
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);

            // Check if near mama cow to stop following
            float distanceToMamaCow = Vector2.Distance(transform.position, mamaCowTransform.position);
            Debug.Log("Distance to Mama Cow: " + distanceToMamaCow);


            if (distanceToMamaCow <= stopDistance)
            {
                isFollowing = false;
                Debug.Log("Near Mama Cow");
                Debug.Log("Stopped Following Player");
                transform.position = Vector2.MoveTowards(transform.position, mamaCowTransform.position, moveSpeed * Time.deltaTime);
                // Optionally, perform any actions when near the mama cow (e.g., stop animations, trigger events)
            }
        }
        else
        {
            isFollowing = false;
        }
    }
}
