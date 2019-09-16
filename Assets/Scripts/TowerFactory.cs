using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
	[SerializeField] Tower tower;
	[SerializeField] int towerLimit = 10;
	[SerializeField] Transform towerParent;

	Queue<Tower> towerQueue = new Queue<Tower>(); 

	public void SpawnTower(Waypoint baseWaypoint) {
		if (towerQueue.Count < towerLimit) {
			InstantiateTower(baseWaypoint);
		} else {
			MoveExistingTower(baseWaypoint);
		}
	}

	void InstantiateTower(Waypoint baseWaypoint) {
		var newTower = Instantiate(tower, baseWaypoint.transform.position, Quaternion.identity);
		newTower.transform.parent = towerParent;

		baseWaypoint.placeable = false;
		newTower.baseWaypoint = baseWaypoint;

		towerQueue.Enqueue(newTower);
	}

	void MoveExistingTower(Waypoint newBaseWaypoint) {
		print("Can't place more");

		var oldTower = towerQueue.Dequeue();

		oldTower.baseWaypoint.placeable = true;
		newBaseWaypoint.placeable = false;
		oldTower.baseWaypoint = newBaseWaypoint;

		oldTower.transform.position = newBaseWaypoint.transform.position;
		
		towerQueue.Enqueue(oldTower);
	}
}