using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	[SerializeField] int health = 3;
	[SerializeField] Text healthText;
	[SerializeField] AudioClip breached;

	void Start() {
		healthText.text = health.ToString();
	}

	void OnTriggerEnter(Collider other) {
		health--;
		GetComponent<AudioSource>().PlayOneShot(breached);
		healthText.text = health.ToString();
		if (health <= 0) {
			print("Game Over!");
		}
	}
}