using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public GameObject player;

	float circleArea = 10;
	float minDistanceFromPlayer = 6;

	int maxEnemies = 1;
	int currentNumberOfEnemies = 0;

	// Start is called before the first frame update
	void Start()
	{
		SpawnEnemy();
	}

	public void SpawnMoreEnemies()
	{
		if (currentNumberOfEnemies <= maxEnemies)
		{
			maxEnemies++;
		}
		currentNumberOfEnemies--;

		maxEnemies = Mathf.Clamp(maxEnemies, 0, 10);

		for (int i = 0; i < maxEnemies - currentNumberOfEnemies; i++)
		{
			SpawnEnemy();
		}
	}

	void SpawnEnemy()
	{
		//increase current number of enemies
		currentNumberOfEnemies++;

		Vector3 randomPosition = Random.insideUnitCircle * circleArea;

		while (randomPosition.sqrMagnitude < minDistanceFromPlayer * minDistanceFromPlayer)
		{
			randomPosition = Random.insideUnitCircle * circleArea;
		}

		Instantiate(enemyPrefab, player.transform.position + randomPosition, transform.rotation);
	}
}
