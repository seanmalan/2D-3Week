using UnityEngine;

public class BadFoodSpawner : MonoBehaviour
{
    public GameObject badFoodPrefab; // Assign this in the Inspector
    public int badFoodCount = 5;

    public void SpawnBadFood(Vector3 position)
    {
        Instantiate(badFoodPrefab, position, Quaternion.identity);
    }

    void Start()
    {
        // Example usage: Spawn 5 bad foods at random positions
        for (int i = 0; i < badFoodCount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-50f, 50f), 0f);
            SpawnBadFood(randomPosition);
        }
    }
}
