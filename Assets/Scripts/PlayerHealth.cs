using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	[SerializeField] int health = 3;

	void OnTriggerEnter(Collider other) {
		health--;
		if (health <= 0) {
			print("Game Over!");
		}
	}
}