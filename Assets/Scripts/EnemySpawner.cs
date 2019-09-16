using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[Range(0.1f, 30f)][SerializeField] float secondsBetweenSpawns = 5f;
	[SerializeField] EnemyMovement enemy;
	[SerializeField] Transform parent;

	void Start() {
		StartCoroutine(SpawnEnemies());
	}

	IEnumerator SpawnEnemies() {
		while (true) {
			var enemyClone = Instantiate(enemy, transform.position, Quaternion.identity);
			enemyClone.transform.parent = parent;
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
}
