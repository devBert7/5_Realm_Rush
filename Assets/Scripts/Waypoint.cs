﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
	const int gridSize = 10;
	Vector2Int gridPos;
	public bool isExplored = false;
	public Waypoint exploredFrom;
	public bool placeable = true;

	public int GetGridSize() {
		return gridSize;
	}

	public Vector2Int GetGridPos() {
		return new Vector2Int(
			Mathf.RoundToInt(transform.position.x / gridSize),
			Mathf.RoundToInt(transform.position.z / gridSize)
		);
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0) && placeable) {
			FindObjectOfType<TowerFactory>().SpawnTower(this);
		}
	}
}