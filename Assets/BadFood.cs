using UnityEngine;

public class BedFood : MonoBehaviour
{

    Audiomanager Audiomanager;

    private void Awake()
    {
        Audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Audiomanager.PlayBadFood(Audiomanager.BadFood); // Play bad food sound
            // Decrease player's hunger by 20 when they touch bad food
            other.GetComponent<PlayerHunger>().EatBadFood();
            Destroy(gameObject); // Destroy the bad food item
        }
    }
}
