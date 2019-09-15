using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
	[SerializeField] int hitPoints = 27;
	[SerializeField] ParticleSystem hitParticles;
	[SerializeField] ParticleSystem deathParticles;

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
		hitParticles.Play();
	}

	void KillEnemy() {
		var dfx = Instantiate(deathParticles, transform.position, Quaternion.identity);
		dfx.Play();
		Destroy(gameObject);
	}
}