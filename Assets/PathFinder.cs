using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	[SerializeField] Waypoint startWaypoint, endWaypoint;
	Queue<Waypoint> queue = new Queue<Waypoint>();
	bool isRunning = true;
	Vector2Int[] directions = {
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	// Start is called before the first frame update
	void Start() {
		LoadBlocks();
		ColorStartAndEnd();
		PathFind();
		// ExploreNeighbors();
	}

	void PathFind() {
		queue.Enqueue(startWaypoint);
		while(queue.Count > 0) {
			var searchCenter = queue.Dequeue();
			print("Searching From: " + searchCenter);
			HaltIfEnd(searchCenter);
		}
		print("Finished Path Finding?");
	}

	void HaltIfEnd(Waypoint searchCenter) {
		if (searchCenter == endWaypoint) {
			print("You have reached the end");
			isRunning = false;
		} else {
			// Explore Neighbors
			print("explore neighbors");
		}
	}

	void ExploreNeighbors() {
		foreach(Vector2Int direction in directions) {
			print("Exploring " + (startWaypoint.GetGridPos() + direction));
			try {
				grid[startWaypoint.GetGridPos() + direction].TopCubeColor(Color.blue);
			} catch {
				// do nothing
			}
		}
	}

	void ColorStartAndEnd() {
		startWaypoint.TopCubeColor(Color.green);
		endWaypoint.TopCubeColor(Color.red);
	}

	void LoadBlocks() {
		var waypoints = FindObjectsOfType<Waypoint>();

		foreach (Waypoint waypoint in waypoints) {
			var gridPos = waypoint.GetGridPos();
			if (grid.ContainsKey(gridPos)) {
				Debug.LogWarning("Skipping Overlapping " + waypoint);
			} else {
				grid.Add(gridPos, waypoint);
			}
		}
	}
}