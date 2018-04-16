using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour 
{
	public Text textVelocity;
	public Text textPosition;
	//public Text textLap;

	public Auto player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		textVelocity.text = (int)player.currentSpeed + "MPH";

	}
}
