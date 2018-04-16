using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Auto))]
public class RivalCar : MonoBehaviour 
{
	Auto auto;
	int currentWaypoint;

	public Transform[] waypoints;

	void Start()
	{
		auto = GetComponent<Auto> ();
	}
	void Update () 
	{
		auto.accel = true;
		var dis = waypoints [currentWaypoint].position - transform.position;
		dis.Normalize ();
		float rot = Mathf.Atan2 (dis.y, dis.x) * Mathf.Rad2Deg;
		rot = -rot + 90;
		auto.rotation = (int)rot;


		if (Vector3.Distance (waypoints [currentWaypoint].position, transform.position) < 1f) {
			currentWaypoint++;
			if (currentWaypoint >= waypoints.Length)
				currentWaypoint = 0;
		}
	}
}
