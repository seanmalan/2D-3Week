using UnityEngine;

public class GoodFood : MonoBehaviour
{
    // I want this function to have my player walk over the food and have the playerHunger go up by 25 and the food to disappear    // I want this function to have my player walk over the food and have the playerHunger go up by 25 and the food to disappear
    
    public int foodValue = 25;

    Audiomanager Audiomanager;


    private void Awake()
    {
        Audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided with the food
        if (other.CompareTag("Player"))
        {
            
            Audiomanager.PlayGoodFood(Audiomanager.GoodFood);
            // Destroy the food object
            Destroy(gameObject);
        }
    }





}
