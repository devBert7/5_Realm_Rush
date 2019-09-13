using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[SerializeField] float secondsBetweenSpawns = 3f;
	[SerializeField] EnemyMovement enemy;

	void Start() {
		StartCoroutine(SpawnEnemies());
	}

	IEnumerator SpawnEnemies() {
		while (true) {
			print("Spawinging");
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
}
