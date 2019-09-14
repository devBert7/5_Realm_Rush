using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	// Parameters
	[SerializeField] Transform objectToPan;
	[SerializeField] float attackRange = 50f;
	[SerializeField] ParticleSystem projectile;

	// State
	Transform targetEnemy;

	void Update() {
		SetTarget();

		if (targetEnemy) {
			objectToPan.LookAt(targetEnemy);
			FireAtEnemy();
			} else {
				Shoot(false);
			}
	}

	void SetTarget() {
		var sceneEnemies = FindObjectsOfType<EnemyDamage>();

		if (sceneEnemies.Length == 0) {
			return;
		}

		Transform closestEnemy = sceneEnemies[0].transform;

		foreach (EnemyDamage spawned in sceneEnemies) {
			closestEnemy = GetClosest(closestEnemy, spawned.transform);
		}

		targetEnemy = closestEnemy;
	}

	Transform GetClosest(Transform closestEnemy, Transform spawned) {
		float distanceToSpawned = Vector3.Distance(spawned.transform.position, gameObject.transform.position);
		float distanceToLast = Vector3.Distance(closestEnemy.transform.position, gameObject.transform.position);

		if (distanceToSpawned < distanceToLast) {
			return spawned;
		} else {
			return closestEnemy;
		}
	}

	void FireAtEnemy() {
		float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
		if (distanceToEnemy <= attackRange) {
			Shoot(true);
		} else {
			Shoot(false);
		}
	}

	void Shoot(bool isActive) {
		var emissionModule = projectile.emission;
		emissionModule.enabled = isActive;
	}
}