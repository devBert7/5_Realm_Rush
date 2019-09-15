using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
	[SerializeField] GameObject tower;
	[SerializeField] int towerLimit = 10;

	public void SpawnTower(Waypoint baseWaypoint) {
		if (FindObjectsOfType<Tower>().Length < towerLimit) {
			InstantiateTower();
		} else {
			MoveExistingTower();
		}
	}

	void InstantiateTower() {
		Instantiate(tower, baseWaypoint.transform.position, Quaternion.identity);
		baseWaypoint.placeable = false;
	}

	void MoveExistingTower() {
		print("Can't place more");
		print(FindObjectsOfType<Tower>().Length);
	}
}