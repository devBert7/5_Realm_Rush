using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
	[SerializeField] int hitPoints = 30;

	// Start is called before the first frame update
	void Start() {
	}

	void OnParticleCollision(GameObject other) {
		ProcessHit();
		if (hitPoints < 1) {
			KillEnemy();
		}
	}

	void ProcessHit() {
		hitPoints--;
		print("Remaining HP: " + hitPoints);
	}

	void KillEnemy() {
		Destroy(gameObject);
	}
}