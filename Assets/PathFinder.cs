using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	[SerializeField] Waypoint startWaypoint, endWaypoint;
	Queue<Waypoint> queue = new Queue<Waypoint>();
	bool isRunning = true;
	Waypoint searchCenter;
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
		while(queue.Count > 0 && isRunning) {
			searchCenter = queue.Dequeue();
			searchCenter.isExplored = true;
			HaltIfEnd();
			ExploreNeighbors();
		}
		// todo - work out path we went down
		print("Finished Path Finding?");
	}

	void HaltIfEnd() {
		if (searchCenter == endWaypoint) {
			isRunning = false;
		}
	}

	void ExploreNeighbors() {
		if (!isRunning) {
			return;
		}

		foreach(Vector2Int direction in directions) {
			Vector2Int neighborCoordinates = searchCenter.GetGridPos() + direction;

			try {
				QueueNewNeighbors(neighborCoordinates);
			} catch {
				// do nothing
			}
		}
	}

	void QueueNewNeighbors(Vector2Int neighborCoordinates) {
		Waypoint neighbor = grid[neighborCoordinates];
		if (neighbor.isExplored || queue.Contains(neighbor)) {
			// Do nothing
		} else {
			queue.Enqueue(neighbor);
			neighbor.exploredFrom = searchCenter;
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