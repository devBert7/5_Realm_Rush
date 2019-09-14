using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[Range(0.1f, 30f)][SerializeField] float secondsBetweenSpawns = 5f;
	[SerializeField] EnemyMovement enemy;

	void Start() {
		StartCoroutine(SpawnEnemies());
	}

	IEnumerator SpawnEnemies() {
		while (true) {
			Instantiate(enemy, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
}
