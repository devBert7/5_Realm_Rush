using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
	const int gridSize = 10;
	Vector2Int gridPos;
	public bool isExplored = false;
	public Waypoint exploredFrom;

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
		Debug.Log("Mouse is over Cube " + gameObject.name);
		print("Mouse Over Event " + gameObject.name);
	}
}