using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	[SerializeField] Transform objectToPan;
	[SerializeField] Transform targetEnemy;
	[SerializeField] float attackRange = 50f;
	[SerializeField] ParticleSystem projectile;

	void Update() {
		if (targetEnemy) {
			objectToPan.LookAt(targetEnemy);
			FireAtEnemy();
			} else {
				Shoot(false);
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