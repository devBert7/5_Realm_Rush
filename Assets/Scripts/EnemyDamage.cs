using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
	[SerializeField] int hitPoints = 27;
	[SerializeField] ParticleSystem hitParticles;
	[SerializeField] ParticleSystem deathParticles;
	[SerializeField] AudioClip enemyHitSFX;
	[SerializeField] AudioClip enemyDeathSFX;

	AudioSource myAudioSource;

	void Start() {
		myAudioSource = GetComponent<AudioSource>();
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
		myAudioSource.PlayOneShot(enemyHitSFX);
	}

	void KillEnemy() {
		var dfx = Instantiate(deathParticles, transform.position, Quaternion.identity);
		dfx.Play();
		Destroy(gameObject);
	}
}