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
			waypoint.GetGridPos().x * gridSize,
			0f,
			waypoint.GetGridPos().y * gridSize
		);
	}

	void UpdateLabel() {
		string labelText = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;

		TextMesh textMesh = GetComponentInChildren<TextMesh>();
		textMesh.text = labelText;
		this.name = "Cube " + labelText; // this.name == gameObject.name (true)
	}
}