﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	[SerializeField] Waypoint startWaypoint, endWaypoint;
	Queue<Waypoint> queue = new Queue<Waypoint>();
	bool isRunning = true;
	Waypoint searchCenter;
	List<Waypoint> path = new List<Waypoint>();
	Vector2Int[] directions = {
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	public List<Waypoint> GetPath() {
		if (path.Count == 0) {
			CalculatePath();
		}
		
		return path;
	}

	void CalculatePath() {
		LoadBlocks();
		BreadthFirstSearch();
		CreatePath();
	}

	void CreatePath() {
		SetAsPath(endWaypoint);

		Waypoint previous = endWaypoint.exploredFrom;

		while (previous != startWaypoint) {
			SetAsPath(previous);
			previous = previous.exploredFrom;
		}
		SetAsPath(startWaypoint);
		path.Reverse();
	}

	void SetAsPath(Waypoint waypoint) {
		path.Add(waypoint);
		waypoint.placeable = false;
	}

	void BreadthFirstSearch() {
		queue.Enqueue(startWaypoint);
		while(queue.Count > 0 && isRunning) {
			searchCenter = queue.Dequeue();
			searchCenter.isExplored = true;
			HaltIfEnd();
			ExploreNeighbors();
		}
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

			if (grid.ContainsKey(neighborCoordinates)) {
				QueueNewNeighbors(neighborCoordinates);
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