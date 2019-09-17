using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	[SerializeField] float movementPeriod = .59f;
	[SerializeField] ParticleSystem explode;

	void Start() {
		PathFinder pathFinder = FindObjectOfType<PathFinder>();
		var path = pathFinder.GetPath();  // List of Waypoints
		StartCoroutine(WaypointTracker(path));
	}

	IEnumerator WaypointTracker(List<Waypoint> path) {
		foreach (Waypoint waypoint in path) {
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(movementPeriod);
		}
		SelfDestruct();
	}

	void SelfDestruct() {
		var explosion = Instantiate(explode, transform.position, Quaternion.identity);
		explosion.Play();
		Destroy(gameObject);
	}
}