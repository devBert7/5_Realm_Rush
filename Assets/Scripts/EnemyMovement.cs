using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	[SerializeField] float movementPeriod = 1f;

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
	}
}