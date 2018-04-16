using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Auto))]
public class PlayerController : MonoBehaviour 
{
	Auto auto;

	void Start()
	{
		auto = GetComponent<Auto> ();
	}

	void Update () 
	{
		auto.accel = Input.GetKey (KeyCode.Z);
		auto.rotation += (int)(auto.steerSpeed * Time.deltaTime * Input.GetAxis ("Horizontal"));
	}
}
