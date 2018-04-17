using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWaypoint : MonoBehaviour {

	public Racer[] racers;
	List<Collider2D> racerList = new List<Collider2D>();
	bool ready;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (ready)
			return;
		
		if (col.CompareTag ("Racer")) {
			if (racerList.Contains (col)) {
				racerList.Remove (col);
			} else {
				racerList.Add (col);
			}		
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (racerList.Count == racers.Length) {
			tag = "Waypoint";				
			ready = true;
		}
	}


}
