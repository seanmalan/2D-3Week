using UnityEngine;

public class GoodFoodSpawner : MonoBehaviour
{
    public GameObject goodFoodPrefab; // Assign this in the Inspector
    public int goodFoodCount = 5;

    public void SpawnGoodFood(Vector3 position)
    {
        Instantiate(goodFoodPrefab, position, Quaternion.identity);
    }

    void Start()
    {
        // Example usage: Spawn 5 good foods at random positions
        for (int i = 0; i < goodFoodCount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-50f, 50f), 0f);
            SpawnGoodFood(randomPosition);
        }
    }
}
