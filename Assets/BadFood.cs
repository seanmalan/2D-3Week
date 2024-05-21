using UnityEngine;

public class BedFood : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("Player touched Bad food!");
            // Decrease player's hunger by 20 when they touch bad food
            other.GetComponent<PlayerHunger>().EatBadFood();
            Destroy(gameObject); // Destroy the bad food item
        }
    }
}
