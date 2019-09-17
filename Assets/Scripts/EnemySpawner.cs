using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
	[Range(0.1f, 30f)][SerializeField] float secondsBetweenSpawns = 3f;
	[SerializeField] EnemyMovement enemy;
	[SerializeField] Transform parent;
	[SerializeField] Text enemyText;
	[SerializeField] AudioClip enemySpawnSFX;
	int numEnemies;

	void Start() {
		StartCoroutine(SpawnEnemies());
		enemyText.text = numEnemies.ToString();
	}

	IEnumerator SpawnEnemies() {
		while (true) {
			AddScore();
			GetComponent<AudioSource>().PlayOneShot(enemySpawnSFX);
			var enemyClone = Instantiate(enemy, transform.position, Quaternion.identity);
			enemyClone.transform.parent = parent;
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}

	void AddScore() {
		numEnemies++;
		enemyText.text = numEnemies.ToString();
	}
}
