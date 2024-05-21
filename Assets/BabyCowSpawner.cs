using UnityEngine;

public class BabyCowSpawner : MonoBehaviour
{
    public GameObject babyCowPrefab; // Assign this in the Inspector

    public void SpawnBabyCow(Vector3 position)
    {
        Instantiate(babyCowPrefab, position, Quaternion.identity);
    }

    void Start()
    {
        // Example usage: Spawn 5 baby cows at random positions
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
            SpawnBabyCow(randomPosition);
        }
    }
}
