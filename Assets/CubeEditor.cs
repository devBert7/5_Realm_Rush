using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))] // Cube editor will find Waypoint component (script) and ensure it's attached
public class CubeEditor : MonoBehaviour {
	Waypoint waypoint;

	void Awake() {
		waypoint = GetComponent<Waypoint>();
	}

	void Update() {

		SnapToGrid();
		UpdateLabel();
	}

	void SnapToGrid() {
		int gridSize = waypoint.GetGridSize();

		transform.position = new Vector3(
			waypoint.GetGridPos().x,
			0f,
			waypoint.GetGridPos().y
		);
	}

	void UpdateLabel() {
		int gridSize = waypoint.GetGridSize();
		string labelText = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;

		TextMesh textMesh = GetComponentInChildren<TextMesh>();
		textMesh.text = labelText;
		this.name = "Cube " + labelText; // this.name == gameObject.name (true)
	}
}