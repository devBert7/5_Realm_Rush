using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
	[Range(0.1f, 30f)][SerializeField] float secondsBetweenSpawns = 5f;
	[SerializeField] EnemyMovement enemy;
	[SerializeField] Transform parent;
	[SerializeField] Text enemyText;
	int numEnemies;

	void Start() {
		StartCoroutine(SpawnEnemies());
		enemyText.text = numEnemies.ToString();
	}

	IEnumerator SpawnEnemies() {
		while (true) {
			numEnemies++;
			enemyText.text = numEnemies.ToString();
			var enemyClone = Instantiate(enemy, transform.position, Quaternion.identity);
			enemyClone.transform.parent = parent;
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
}
