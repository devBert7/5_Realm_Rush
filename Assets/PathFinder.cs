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
		while(queue.Count > 0 && isRunning) {
			var searchCenter = queue.Dequeue();
			print("Searching From: " + searchCenter); // todo remove
			searchCenter.isExplored = true;
			HaltIfEnd(searchCenter);
			ExploreNeighbors(searchCenter);
		}
		// todo - work out path we went down
		print("Finished Path Finding?");
	}

	void HaltIfEnd(Waypoint searchCenter) {
		if (searchCenter == endWaypoint) {
			print("You have reached the end"); // todo remove
			isRunning = false;
		}
	}

	void ExploreNeighbors(Waypoint from) {
		if (!isRunning) {
			return;
		}

		foreach(Vector2Int direction in directions) {
			Vector2Int neighborCoordinates = from.GetGridPos() + direction;

			try {
				QueueNewNeighbors(neighborCoordinates);
			} catch {
				// do nothing
			}
		}
	}

	void QueueNewNeighbors(Vector2Int neighborCoordinates) {
		Waypoint neighbor = grid[neighborCoordinates];
		neighbor.TopCubeColor(Color.blue); // todo move elsewhere
		if (!neighbor.isExplored) {
			queue.Enqueue(neighbor);
			print("Queueing Neighbor " + neighbor); // todo remove
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