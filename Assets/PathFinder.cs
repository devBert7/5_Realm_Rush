using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	[SerializeField] Waypoint startWaypoint, endWaypoint;

	// Start is called before the first frame update
	void Start() {
		LoadBlocks();
		ColorStartAndEnd();
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